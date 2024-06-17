import styles from "./ServerError.module.css"

const ServerError = () => {
    return (
        <div className={styles.wrapper}>
            <p className={styles.error} >Could not get data from server</p>
        </div>
    )
}

export {
    ServerError,
}