import { useState } from "react"
import { AboutButton, AboutButtonProps } from "./AboutButton/AboutButton"
import { generateUID, joinClassName } from "../../functions/functions"
import styles from "./AboutField.module.css"
import { AboutText, AboutTextProps } from "./AboutText/AboutText"
import { CurrencyObjectType } from "../../types/types"

type AboutFieldProps = {
    id: string,
    purchasedCurrency?: CurrencyObjectType,
    paymentCurrency?: CurrencyObjectType,
}

const AboutField = (props: AboutFieldProps) => {
    const {
        id,
        purchasedCurrency,
        paymentCurrency,
    } = props
    const [opened, setOpened] = useState<boolean>(false)
    const AboutButtonProps: AboutButtonProps = {
        id: generateUID(),
        purchasedCurrencyCode: purchasedCurrency?.code,
        paymentCurrencyCode: paymentCurrency?.code,
        onClick: setOpened,
    }
    const AboutPurchasedCurrency: AboutTextProps = {
        id: generateUID(),
        currencyInfo: purchasedCurrency,
    }
    const AboutPaymentCurrency: AboutTextProps = {
        id: generateUID(),
        currencyInfo: paymentCurrency,
    }
    return (
        <div className={joinClassName(id, styles.wrapper)}>
            <AboutButton {...AboutButtonProps}/>
            {opened 
                ? <>
                    <AboutText {...AboutPurchasedCurrency}/>
                    <AboutText {...AboutPaymentCurrency}/>
                </> : null}
        </div>
    )
}

export {
    AboutField,
}

export type {
    AboutFieldProps,
}