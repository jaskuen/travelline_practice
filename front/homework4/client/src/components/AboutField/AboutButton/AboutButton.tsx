import styles from "./AboutButton.module.css"
import ArrowUp from "../../../../public/arrowUp.svg"
import ArrowDown from "../../../../public/arrowDown.svg"
import { useState } from "react"

type AboutButtonProps = {
    id: string,
    purchasedCurrencyCode?: string,
    paymentCurrencyCode?: string,
    onClick: (b: boolean) => void,
}

const AboutButton = (props: AboutButtonProps) => {
    const {
        purchasedCurrencyCode,
        paymentCurrencyCode,
        onClick,
    } = props

    const handleClick = () => {
        setClicked(!clicked)
        onClick(!clicked)
    }

    const [clicked, setClicked] = useState<boolean>(false)
    return (
        <div className={styles.wrapper}>
            <button className={styles.button} onClick={handleClick}>
                {purchasedCurrencyCode}/{paymentCurrencyCode}: about
                <img className={styles.arrow} src={clicked ? ArrowUp : ArrowDown} />
            </button>
        </div>
    )
}

export {
    AboutButton,
}

export type {
    AboutButtonProps,
}