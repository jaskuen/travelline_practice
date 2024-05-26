import styles from "./Rate.module.css"
import { RangeField, RangeFieldProps } from "./RangeFieldComponent/RangeField"
import { generateUID, joinClassName } from "../../../public/functions"
import { useEffect, useState } from "react"

type RateProps = {
    id: string,
    text: string,
    handleChange: (num: number) => void
}

const Rate = (props: RateProps) => {
    const {
        id,
        text,
        handleChange,
    } = props
    const RangeFieldProps: RangeFieldProps = {
        id: generateUID(),
        handleRangeChange: (newRate: number) => handleChange(newRate)
    }
    return (
        <div className={joinClassName(id, styles.rate)}>
            <RangeField {...RangeFieldProps}/>
            <div className={styles.text}>
                {text}
            </div>
        </div>
    )    
}

export {
    Rate,
}

export type {
    RateProps,
}