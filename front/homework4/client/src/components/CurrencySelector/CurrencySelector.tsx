import { joinClassName } from "../../functions/functions"
import styles from "./CurrencySelector.module.css"

type CurrencySelectorProps = {
    id: string,
    calculatedValue?: number,
    onChange: (num: number) => void,
    anotherInputChange: (num: number) => void,
    multiplier: number,
    getCurrency: (name: string) => void,
    currencyCodesList: Array<string>,
    currentCurrency?: string,
}
const CurrencySelector = (props: CurrencySelectorProps) => {
    const {
        id,
        calculatedValue,
        onChange,
        anotherInputChange,
        multiplier,
        getCurrency,
        currencyCodesList,
        currentCurrency,
    } = props

    // const validateInput = (event) => {

    // }

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const newValue: number = Number(event.target.value)
        onChange(newValue)
        anotherInputChange(newValue * multiplier)
    }

    const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        getCurrency(event.target.value)
    }

    return (
    <div className={joinClassName(id, styles.wrapper)} >
        <input className={styles.input} type="number" value={calculatedValue ? calculatedValue : 1} onChange={handleInputChange} />
        <div className={styles.divider} />
        <select className={styles.select} value={currentCurrency ? currentCurrency : undefined} onChange={handleSelectChange}>
            {currencyCodesList.map(currencyCode => {
                return (<option value={currencyCode}>{currencyCode}</option>)
            })}
        </select>
    </div>
    )
}

export {
    CurrencySelector,
}

export type {
    CurrencySelectorProps,
}