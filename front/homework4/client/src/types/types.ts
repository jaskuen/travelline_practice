import { ChartData } from "chart.js"

type CurrencyObjectType = {
    code: string,
    name: string,
    description: string,
    symbol: string,
}

type CurrencyPair = {
    purchasedCurrencyCode: string,
    paymentCurrencyCode: string,
}

type CurrencyPairWithPrice = CurrencyPair & {
    price: number,
}

type CurrencyExchangeRateType = CurrencyPairWithPrice & {
    dateTime: string,
}

type RateChartProps = {
    id?: string | undefined,
    rateData?: ChartData<'line', number[], string> | undefined,
}


export type {
    CurrencyObjectType,
    CurrencyExchangeRateType,
    RateChartProps,
    CurrencyPair,
    CurrencyPairWithPrice,
}