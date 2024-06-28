import { joinClassName } from "../../../public/functions"
import styles from "./Button.module.css"

type ButtonType = 'default' | 'hover' | 'active' | 'disabled'

type ButtonProps = {
    id: string
    disabled: boolean
    name: string
    onClick: () => void
}

const Button = (props: ButtonProps) => {
    const {
        id,
        disabled,
        name,
        onClick,
    } = props
    return (
        <button className={joinClassName(id, styles.button)} disabled={disabled} onClick={onClick}>
            {name}
        </button>
    )
}

export {
    Button,
}