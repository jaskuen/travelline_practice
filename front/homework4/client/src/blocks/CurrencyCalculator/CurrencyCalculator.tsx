import { useEffect, useState } from "react";
import { CurrencySelector, CurrencySelectorProps } from "../../components/CurrencySelector/CurrencySelector";
import { generateUID, getCurrencyExchangeRates, getCurrencyInformation } from "../../functions/functions";
import { CurrencyExchangeRateType, CurrencyObjectType } from "../../types/types";
import styles from "./CurrencyCalculator.module.css"
import { AboutField, AboutFieldProps } from "../../components/AboutField/AboutField";
import { Loader } from "../Loader/Loader";
import { ServerError } from "../ServerError/ServerError";
import { RateChart, RateChartProps } from "../../components/RateChart/RateChart";

type pageLoaderType = "loading" | "success" | "error"

const CurrencyCalculator = () => {
    const [pageLoaded, setPageLoaded] = useState<pageLoaderType>("loading")
    const [currencyList, setCurrencyList] = useState<Array<CurrencyObjectType>>([])
    const [paymentInputValue, setPaymentInputValue] = useState<number>(1)
    const [purchasedInputValue, setPurchasedInputValue] = useState<number>(1)
    const [paymentCurrency, setPaymentCurrency] = useState<string>("PLN")
    const [purchasedCurrency, setPurchasedCurrency] = useState<string>("JPY")
    const [exchangeRate, setExchangeRate] = useState<Array<CurrencyExchangeRateType>>([])
    
    useEffect(() => {
        try {
            getCurrencyInformation(setCurrencyList)
            getCurrencyExchangeRates(paymentCurrency, purchasedCurrency, setExchangeRate)
        }
        catch (error) {
            console.log(error)
            setPageLoaded("error")
        }
        finally {
            setInterval(() => {
                getCurrencyExchangeRates(paymentCurrency, purchasedCurrency, setExchangeRate)
            }, 10000)
            setTimeout(() => {
                setPageLoaded("success")
            }, 1000)
            console.log('Data loaded successfully, delay 1 second before page load')
        }
    }, [])

    useEffect(() => {
        getCurrencyExchangeRates(paymentCurrency, purchasedCurrency, setExchangeRate)
    }, [paymentCurrency, purchasedCurrency])

    useEffect(() => {
        exchangeRate?.[0]?.price ? setPurchasedInputValue(paymentInputValue * exchangeRate[0].price) : null
    }, [exchangeRate])

    const paymentProps: CurrencySelectorProps = {
        id: generateUID(),
        calculatedValue: paymentInputValue,
        onChange: setPaymentInputValue,
        anotherInputChange: setPurchasedInputValue,
        multiplier: exchangeRate?.[0]?.price ?? 1,
        getCurrency: setPaymentCurrency,
        currentCurrency: paymentCurrency,
        currencyCodesList: currencyList.map(currency => {return currency.code})
    }
    const purchasedProps: CurrencySelectorProps = {
        id: generateUID(),
        calculatedValue: purchasedInputValue,
        onChange: setPurchasedInputValue,
        anotherInputChange: setPaymentInputValue,
        multiplier: exchangeRate?.[0]?.price ? 1 / exchangeRate[0].price : 1,
        getCurrency: setPurchasedCurrency,
        currentCurrency: purchasedCurrency,
        currencyCodesList: currencyList.map(currency => {return currency.code})
    }
    const aboutProps: AboutFieldProps = {
        id: generateUID(),
        purchasedCurrency: currencyList.length > 0 ? currencyList.find(currency => currency.code == purchasedCurrency) : undefined,
        paymentCurrency: currencyList.length > 0 ?currencyList.find(currency => currency.code == paymentCurrency) : undefined,
    }
    const rateChartProps: RateChartProps = {
        id: generateUID(),
        rateData: {
            data: {
                labels: exchangeRate.map(rate => {return rate.dateTime}),
                datasets: [{
                    label: 'aa',
                    data: exchangeRate.map(rate => {return rate.price}),
            }]}
        }
    }
    return (
        <>
            {pageLoaded == "loading" 
                ? <Loader /> 
                : pageLoaded == "error" ? <ServerError />
                : <div className={styles.wrapper}>
                    <div className={styles.calculatorWrapper} >
                        <div className={styles.currenciesWrapper} >
                            <h3 className={styles.paymentCurrency}>
                                1 {paymentCurrency} is
                            </h3>
                            <h1 className={styles.purchasedCurrency}>
                                {exchangeRate.length > 0 && exchangeRate[0].price ? exchangeRate[0].price : "unknown"} {purchasedCurrency}
                            </h1>
                            <h4 className={styles.currentDate}>
                                {new Date().toUTCString()}
                            </h4>
                            <CurrencySelector {...paymentProps}/>
                            <CurrencySelector {...purchasedProps}/>
                        </div>
                        <RateChart {...rateChartProps}/>
                    </div>
                    <AboutField {...aboutProps}/>
                </div>
            } 
        </>
    )
}

export {
    CurrencyCalculator,
}