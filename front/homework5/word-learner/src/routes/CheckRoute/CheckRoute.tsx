import { useWordStore } from "../../functions/functions"
import styles from "./CheckRoute.module.scss"

const CheckRoute = () => {
    const {words} = useWordStore()
    return (
        <div className={styles.wrapper}>
            
        </div>
    )
}

export {
    CheckRoute,
}