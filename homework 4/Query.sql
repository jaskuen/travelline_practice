IF NOT EXISTS (SELECT * FROM sysobjects	WHERE name='rooms')
	CREATE TABLE dbo.rooms (
		id_room INT IDENTITY(1, 1) NOT NULL,
		room_number INT NOT NULL,
		room_type NVARCHAR(30) NOT NULL,
		price_per_night DECIMAL(6, 2) NOT NULL,
		is_available BIT NOT NULL, /*как я понял, есть два значения: 0 (false) и 1 (true).*/
		
		CONSTRAINT PK_rooms_id_room PRIMARY KEY (id_room),
	)

IF NOT EXISTS (SELECT * FROM sysobjects	WHERE name='customers')
	CREATE TABLE dbo.customers (
		id_customer INT IDENTITY(1, 1) NOT NULL,
		first_name NVARCHAR(30) NOT NULL,
		last_name NVARCHAR(30) NOT NULL,
		email NVARCHAR(50),
		phone_number NVARCHAR(20) NOT NULL,

		CONSTRAINT PK_customers_id_customer PRIMARY KEY (id_customer)
	)

IF NOT EXISTS (SELECT * FROM sysobjects	WHERE name='bookings')
	CREATE TABLE dbo.bookings (
		id_booking INT IDENTITY(1, 1) NOT NULL,
		id_room INT NOT NULL,
		id_customer INT NOT NULL,
		check_in_date DATETIME NOT NULL,
		check_out_date DATETIME NOT NULL,

		CONSTRAINT PK_booking_id_booking PRIMARY KEY (id_booking),

		CONSTRAINT FK_bookings_id_room FOREIGN KEY (id_room) REFERENCES dbo.rooms (id_room),
		CONSTRAINT FK_bookings_id_customer FOREIGN KEY (id_customer) REFERENCES dbo.customers (id_customer)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='facilities')
	CREATE TABLE dbo.facilities (
		id_facility INT IDENTITY(1, 1) NOT NULL,
		facility_name NVARCHAR(200) NOT NULL,

		CONSTRAINT PK_facilities_id_facility PRIMARY KEY (id_facility)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='rooms_to_facilities')
	CREATE TABLE dbo.rooms_to_facilities (
		id_facility INT NOT NULL,
		id_room INT NOT NULL,

		CONSTRAINT PK_rooms_to_facilities_id_room_id_facility PRIMARY KEY (id_facility, id_room),

		CONSTRAINT FK_rooms_id_room FOREIGN KEY (id_room) REFERENCES dbo.rooms (id_room),
		CONSTRAINT FK_facilities_id_facility FOREIGN KEY (id_facility) REFERENCES dbo.facilities (id_facility)
	)

INSERT INTO dbo.rooms (room_number, room_type, price_per_night, is_available)
VALUES
	(10, N'Одна одноместная кровать', 1500, 1),
	(21, N'Две одноместных кровати', 2500, 0),
	(16, N'Одна двухместная кровать', 2000, 1),
	(11, N'Одна одноместная кровать', 1499, 0),
	(22, N'Три одноместных кровати', 3000, 0)

INSERT INTO dbo.customers (first_name,	last_name, phone_number)
VALUES
	(N'Ольга', N'Мамаева', '+7 (111) 000-98-89'),
	(N'Софья', N'Чичикова', '+7 (800) 555-35-36')

INSERT INTO dbo.customers (first_name, last_name, phone_number, email)
VALUES
	(N'Игорь', N'Пономарев', '+7 (999) 123-45-67', 'igorponomarev@mail.ru')


INSERT INTO dbo.bookings (id_room, id_customer, check_in_date, check_out_date)
VALUES
	(1, 7, '2024-04-12T10:00:00', '2024-04-13T08:00:00'),
	(2, 8, '2024-04-10T12:30:00', '2024-04-15T12:30:00')

INSERT INTO dbo.facilities (facility_name)
VALUES
	(N'Wi-Fi'),
	(N'Мини-бар'),
	(N'Панорамное окно'),
	(N'Завтрак включен в стоимость')

INSERT INTO dbo.rooms_to_facilities (id_room, id_facility)
VALUES
	(1, 7),
	(2, 5), (2, 6),
	(3, 8),
	(5, 5), (5, 6), (5, 8)

SELECT * FROM dbo.rooms WHERE (dbo.rooms.is_available = 1)
SELECT * FROM dbo.customers WHERE(dbo.customers.last_name LIKE N'S%')

SELECT * FROM dbo.bookings AS booking
	JOIN dbo.customers AS customer ON booking.id_customer = customer.id_customer
	JOIN dbo.rooms AS room ON booking.id_room = room.id_room
		WHERE customer.first_name = N'Игорь' AND customer.last_name = N'Пономарев' 
			OR customer.email = 'igorponomarev@mail.ru';

SELECT * FROM dbo.bookings AS booking
	JOIN dbo.rooms AS room ON room.id_room = booking.id_room
		WHERE room.room_number = 21

SELECT * FROM dbo.rooms AS room
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.bookings AS booking
    WHERE booking.id_room = room.id_room 
		AND room.is_available = 1
		AND '2024-04-11T10:00:00' BETWEEN booking.check_in_date AND booking.check_out_date
)