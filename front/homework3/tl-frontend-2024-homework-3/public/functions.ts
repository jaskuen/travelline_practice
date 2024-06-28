
function joinClassName(...classNames: string[]): string {
    return classNames.filter(className => className).join(' ');
}

function generateUID() {
    // Генерируем случайную строку из букв и цифр
    var randomPart = Math.random().toString(36).substring(2);
  
    // Текущая дата в формате YYMMDD
    var datePart = new Date()
      .toISOString()
      .substring(2, 10)
      .replace(/-/g, '');
  
    // Создаем уникальный идентификатор
    return 'uid_' + datePart + randomPart;
  }

export {
    joinClassName,
    generateUID,
}