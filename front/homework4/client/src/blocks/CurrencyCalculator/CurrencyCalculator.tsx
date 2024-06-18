import { useEffect, useState } from "react";
import { CurrencySelector, CurrencySelectorProps } from "../../components/CurrencySelector/CurrencySelector";
import { generateUID, getCurrencyExchangeRates, getCurrencyInformation } from "../../functions/functions";
import { CurrencyExchangeRateType, CurrencyObjectType, CurrencyPair, RateChartProps } from "../../types/types";
import styles from "./CurrencyCalculator.module.css"
import { AboutField, AboutFieldProps } from "../../components/AboutField/AboutField";
import { Loader } from "../Loader/Loader";
import { ServerError } from "../ServerError/ServerError";
import { RateChart} from "../../components/RateChart/RateChart";

type pageLoaderType = "loading" | "success" | "error"

const CurrencyCalculator = () => {
    const [pageLoaded, setPageLoaded] = useState<pageLoaderType>("loading")
    const [currencyList, setCurrencyList] = useState<Array<CurrencyObjectType>>([])
    const [paymentInputValue, setPaymentInputValue] = useState<number>(1)
    const [purchasedInputValue, setPurchasedInputValue] = useState<number>(1)
    const [currencyPair, setCurrencyPair] = useState<CurrencyPair>({
        paymentCurrencyCode: "PLN",
        purchasedCurrencyCode: "JPY",
        price: 1,
    })
    const [exchangeRate, setExchangeRate] = useState<Array<CurrencyExchangeRateType>>([])
    const [chartProps, setChartProps] = useState<RateChartProps>()
    
    useEffect(() => {
        try {
            getCurrencyInformation(setCurrencyList)
            getCurrencyExchangeRates(currencyPair.paymentCurrencyCode, currencyPair.purchasedCurrencyCode, setExchangeRate)
        }
        catch (error) {
            console.log(error)
            setPageLoaded("error")
        }
        finally {
            setInterval(() => {
                getCurrencyExchangeRates(currencyPair.paymentCurrencyCode, currencyPair.purchasedCurrencyCode, setExchangeRate)
            }, 10000)
            setTimeout(() => {
                setPageLoaded("success")
            }, 1000)
            console.log('Data loaded successfully, delay 1 second before page load')
        }
    }, [])

    useEffect(() => {
        getCurrencyExchangeRates(currencyPair.paymentCurrencyCode, currencyPair.purchasedCurrencyCode, setExchangeRate)
    }, [currencyPair.paymentCurrencyCode, currencyPair.purchasedCurrencyCode])

    useEffect(() => {
        exchangeRate?.[0]?.price ? setPurchasedInputValue(paymentInputValue * exchangeRate[exchangeRate.length - 1].price) : null
        setChartProps({
            id: generateUID(),
            rateData: {
                    labels: exchangeRate.map(rate => {return rate.dateTime}),
                    datasets: [{
                        label: `${currencyPair.purchasedCurrencyCode}/${currencyPair.paymentCurrencyCode}`,
                        data: exchangeRate.map(rate => {return rate.price}),
                        fill: true,
                        backgroundColor: 'rgba(75,192,192,0.2)',
                        borderColor: 'rgb(75, 192, 192)',
                }]
            }
        })
        setCurrencyPair({
            ...currencyPair,
            price: exchangeRate?.[exchangeRate.length - 1]?.price ?? 1,
        })
    }, [exchangeRate])

    const paymentProps: CurrencySelectorProps = {
        id: generateUID(),
        calculatedValue: paymentInputValue,
        onChange: setPaymentInputValue,
        anotherInputChange: setPurchasedInputValue,
        multiplier: exchangeRate?.[exchangeRate.length - 1]?.price ?? 1,
        getCurrency: (name: string) => setCurrencyPair(name == currencyPair.purchasedCurrencyCode ? {
            ...currencyPair,
            purchasedCurrencyCode: currencyPair.paymentCurrencyCode,
            paymentCurrencyCode: currencyPair.purchasedCurrencyCode,
        } : {
            ...currencyPair,
            paymentCurrencyCode: name,
        }),
        currentCurrency: currencyPair.paymentCurrencyCode,
        currencyCodesList: currencyList.map(currency => {return currency.code})
    }
    const purchasedProps: CurrencySelectorProps = {
        id: generateUID(),
        calculatedValue: purchasedInputValue,
        onChange: setPurchasedInputValue,
        anotherInputChange: setPaymentInputValue,
        multiplier: exchangeRate?.[exchangeRate.length - 1]?.price ? 1 / exchangeRate[exchangeRate.length - 1].price : 1,
        getCurrency: (name: string) => setCurrencyPair(name == currencyPair.paymentCurrencyCode ? {
            ...currencyPair,
            purchasedCurrencyCode: currencyPair.paymentCurrencyCode,
            paymentCurrencyCode: currencyPair.purchasedCurrencyCode,
        } : {
            ...currencyPair,
            purchasedCurrencyCode: name,
        }),
        currentCurrency: currencyPair.purchasedCurrencyCode,
        currencyCodesList: currencyList.map(currency => {return currency.code})
    }
    const aboutProps: AboutFieldProps = {
        id: generateUID(),
        purchasedCurrency: currencyList.length > 0 ? currencyList.find(currency => currency.code == currencyPair.purchasedCurrencyCode) : undefined,
        paymentCurrency: currencyList.length > 0 ?currencyList.find(currency => currency.code == currencyPair.paymentCurrencyCode) : undefined,
    }
    return (
        <>
            {
                pageLoaded == 'loading' ? <Loader /> 
                : pageLoaded == 'error' ? <ServerError />
                : <div className={styles.wrapper} >
                <div className={styles.calculatorWrapper} >
                    <div className={styles.currenciesWrapper} >
                        <h3 className={styles.paymentCurrency}>
                            1 {currencyPair.paymentCurrencyCode} is
                        </h3>
                        <h1 className={styles.purchasedCurrency}>
                            {exchangeRate.length > 0 && exchangeRate[exchangeRate.length - 1].price ? exchangeRate[exchangeRate.length - 1].price : "unknown"} {currencyPair.purchasedCurrencyCode}
                        </h1>
                        <h4 className={styles.currentDate}>
                            {new Date().toUTCString()}
                        </h4>
                        <CurrencySelector {...paymentProps}/>
                        <CurrencySelector {...purchasedProps}/>
                    </div>
                    <RateChart {...chartProps}/>
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