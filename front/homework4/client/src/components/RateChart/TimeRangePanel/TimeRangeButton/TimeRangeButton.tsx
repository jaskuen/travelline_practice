import { TimeRange } from "../../RateChart"
import styles from "./TimeRangeButton.module.css"

type TimeRangeButtonProps = {
    onClick: () => void,
    timeRange: TimeRange,
}

const TimeRangeButton = (props: TimeRangeButtonProps) => {
    const {
        onClick,
        timeRange,
    } = props
    return (
        <button className={styles.button} onClick={onClick} >{timeRange} MIN</button>
    )
}

export {
    TimeRangeButton,
}

export type {
    TimeRangeButtonProps,
}