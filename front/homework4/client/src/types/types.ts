type CurrencyObjectType = {
    code: string,
    name: string,
    description: string,
    symbol: string,
}

type CurrencyExchangeRateType = {
    dateTime: string,
    purchasedCurrencyCode: string,
    paymentCurrencyCode: string,
    price: number,
}

type RateChartType = {
    data: {
        labels: string[],
        datasets: Array<{
            id: string,
            label: string,
            data: number[],
            backgroundColor?: string,
            borderColor?: string,
            borderWidth?: number,
        // Добавьте другие свойства датасета по мере необходимости
        }>,
    },
    options?: {
        scales?: {
        y?: {
            beginAtZero?: boolean,
        },
        // Добавьте другие настройки масштабирования по мере необходимости
    },
    tooltips?: {
        enabled?: boolean,
        mode?: string,
        intersect?: boolean,
        callbacks?: {
            label?: (tooltipItem: any, data: any) => string,
        },
    },
    hover?: {
        mode?: string,
        intersect?: boolean,
    },
    // Добавьте другие опции по мере необходимости
  },
}
export type {
    CurrencyObjectType,
    CurrencyExchangeRateType,
    RateChartType,
}