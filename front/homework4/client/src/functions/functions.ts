import { useEffect, useRef } from "react";
import { CurrencyExchangeRateType, CurrencyObjectType } from "../types/types";

const joinClassName = (...classNames: Array<string>): string => {
    return classNames.filter(Boolean).join(' ');
}

const generateUID = (): string => {
    const length = 6 // length of UID
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    return Array.from({ length }, () => characters.charAt(Math.floor(Math.random() * characters.length))).join('');
}

const usePrevious = (value: any) => {
    const ref = useRef()
    useEffect(() => {
        ref.current = value
    }, [value])
    return ref.current
}

const getCurrencyInformation = async (setCurrencyInformation: (array: CurrencyObjectType[]) => void) => {
    const response = await fetch('http://localhost:5081/Currency')
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`)
    }
    const data = await response.json()
    setCurrencyInformation(data) 
}

const getCurrencyExchangeRates = async (paymentCurrency: string, purchasedCurrency: string, setExchangeRate: (array: Array<CurrencyExchangeRateType>) => void) => {
    const currentDate = new Date()
    currentDate.setMinutes(currentDate.getMinutes() - 5)

    const response = await fetch(`http://localhost:5081/prices/?PaymentCurrency=${paymentCurrency}&PurchasedCurrency=${purchasedCurrency}&FromDateTime=${currentDate.toISOString()}`)
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`)
    }
    const data = await response.json()
    console.log(data)
    setExchangeRate(data)
}

export {
    joinClassName,
    generateUID,
    usePrevious,
    getCurrencyExchangeRates,
    getCurrencyInformation,
}