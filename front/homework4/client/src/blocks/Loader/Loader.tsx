import styles from "./Loader.module.css"
import loadingGif from "../../../public/loading.gif"

const Loader = () => {
    return (
        <div className={styles.loader}>
            <img className={styles.gif} src={loadingGif} />
        </div>
    )
}

export {
    Loader,
}