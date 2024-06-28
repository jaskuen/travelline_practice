import { useEffect, useState } from "react";
import { generateUID } from "../../../public/functions";
import { Rate } from "../../components/RateComponent/Rate";
import styles from "./Ratetable.module.css"

type RateTableProps = {
    getRate: (rate: number) => void,
}

const RateTable = (props: RateTableProps) => {
    const { 
        getRate 
    } = props;
    const namesArray: Array<string> = ["Чистенько",  "Сервис", "Скорость", "Место", "Культура речи"]
    const [average, setAverage] = useState<number>(1)
    useEffect(() => {
        getRate(average)
    }, [average])   
    return (
        <div className={styles.table}>
            {namesArray.map((name: string)  => {
                return (
                    <Rate 
                        id={generateUID()}
                        text={name} 
                        handleChange={
                            (num: number) => {
                                setAverage(average + num)
                            }
                        }/>
                )
                })}
        </div>
    )
}

export {
    RateTable,
}

export type {
    RateTableProps,
}