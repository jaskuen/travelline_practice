import { useEffect, useState } from "react"
import { joinClassName } from "../../functions/functions"
import { CurrencyPair } from "../../types/types"
import styles from "./Filters.module.css"

type FiltersProps = {
    id: string,
    currentPair: CurrencyPair,
    onFilterClick: (filter: CurrencyPair) => void,
}

const Filters = (props: FiltersProps) => {
    const {
        id,
        currentPair,
        onFilterClick,
    } = props

    const [filters, setFilters] = useState<Array<CurrencyPair>>([])

    useEffect(() => {
        setFilters(Object.keys(localStorage).map((key: string) => {
            const item = localStorage.getItem(key)
            if (item) {
                return JSON.parse(item)
            }   
         }))
    }, [])
    const handleFilterClick = (filter: CurrencyPair) => {
        onFilterClick(filter)
    }

    const handleButtonSaveClick = () => {
        localStorage.setItem(`${currentPair.paymentCurrencyCode}/${currentPair.purchasedCurrencyCode}`, JSON.stringify(currentPair))
        setFilters(Object.keys(localStorage).map((key: string) => {
            const item = localStorage.getItem(key)
            if (item) {
                return JSON.parse(item)
            }   
         }))
    }

    const handleButtonDeleteClick = () => {
        localStorage.clear()
        setFilters([])
    }

    return (
        <div className={joinClassName(id, styles.wrapper)}>
            <div className={styles.filtersWrapper} >
                {filters.map(filter => {
                    return (
                        <button 
                            key={`${filter.paymentCurrencyCode}/${filter.purchasedCurrencyCode}`}
                            className={styles.filterButton}
                            onClick={() => handleFilterClick(filter)} 
                        >
                            {filter.paymentCurrencyCode}/{filter.purchasedCurrencyCode}
                        </button>
                    )
                })}
            </div>
            <button className={styles.saveButton} onClick={handleButtonSaveClick}>
                Save filter
            </button>
            <button className={styles.deleteButton} onClick={handleButtonDeleteClick}>
                Clear filters
            </button>
        </div>
    )
}

export {
    Filters,
}

export type {
    FiltersProps,
}