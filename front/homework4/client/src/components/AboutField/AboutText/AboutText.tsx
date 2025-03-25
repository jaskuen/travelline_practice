import { joinClassName } from "../../../functions/functions"
import { CurrencyObjectType } from "../../../types/types"
import styles from "./AboutText.module.css"

type AboutTextProps = {
    id: string, 
    currencyInfo?: CurrencyObjectType,
}

const AboutText = (props: AboutTextProps) => {
    const {
        id,
        currencyInfo,
    } = props
    return (
        <div className={joinClassName(id, styles.wrapper)}>
            <h2 className={styles.name}>{currencyInfo?.name} - {currencyInfo?.code} - {currencyInfo?.symbol}</h2>
            <p className={styles.info}>{currencyInfo?.description}</p>
        </div>
    )
}

export {
    AboutText,
}

export type {
    AboutTextProps,
}