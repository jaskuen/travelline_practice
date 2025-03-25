import styles from "./TimeRangePanel.module.css"
import { TimeRangeButton } from "./TimeRangeButton/TimeRangeButton"
import { useEffect, useState } from "react"
import { TimeRange } from "../RateChart"
import { joinClassName } from "../../../functions/functions"

type TimeRangePanelProps = {
    id: string,
    onChange: (num: TimeRange) => void,
}

const TimeRangePanel = (props: TimeRangePanelProps) => {
    const {
        id,
        onChange,
    } = props

    const [range, setRange] = useState<TimeRange>("1")

    useEffect(() => {
        onChange(range)
    }, [range])

    return (
        <div className={joinClassName(id, styles.wrapper)} >
            <TimeRangeButton onClick={() => setRange("1")} timeRange="1" />
            <TimeRangeButton onClick={() => setRange("2")} timeRange="2" />
            <TimeRangeButton onClick={() => setRange("3")} timeRange="3" />
            <TimeRangeButton onClick={() => setRange("4")} timeRange="4" />
            <TimeRangeButton onClick={() => setRange("5")} timeRange="5" />
        </div> 
    )
}

export {
    TimeRangePanel,
}