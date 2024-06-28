import { useEffect, useState } from "react"
import { joinClassName } from "../../../../public/functions"
import styles from "./RangeField.module.css"

type InputProps = {
    type: string,
    onChange: () => void,
    className: string,
    min: number,
    max: number,
}

type RangeFieldProps = {
    id: string,
    handleRangeChange: (newRate: number) => void,
}

const RangeField = (props: RangeFieldProps) => {
    const {
        id,
        handleRangeChange,
    } = props

    const [rate, setRate] = useState<number>(0)
    const getImage = (num: number): string => {
        switch (num) {
            case 0: return "../../../../public/img/twemoji_angry-face.svg"
            case 1: return "../../../../public/img/twemoji_slightly-frowning-face.svg"
            case 2: return "../../../../public/img/twemoji_neutral-face.svg"
            case 3: return "../../../../public/img/twemoji_slightly-smiling-face.svg"
            case 4: return "../../../../public/img/twemoji_grinning-face-with-big-eyes.svg"
        }
        return ""
    }
    useEffect(() => {
        const slider = document.getElementById(id)
                    if (slider !== null){
                        slider.style.setProperty('--thumb-image', `url('${getImage(0)}')`)
                    }
    }, [])
    return (
        <>
            <input 
                id={id}
                list="rate"
                type="range"
                onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
                    const newValue: number = Number(event.target.value);
                    const slider = document.getElementById(id)
                    if (slider !== null){
                        slider.style.setProperty('--thumb-image', `url('${getImage(newValue)}')`)
                    }
                    handleRangeChange(0.2 * (newValue - rate))
                    setRate(newValue)
                }} 
                className={styles.input}
                min={0} 
                max={4}
                value={rate}
            />
        </>
    )
}

export {
    RangeField,
}

export type {
    RangeFieldProps
}