import { Button, Typography } from "@mui/material"
import { KeyboardArrowLeft } from "@mui/icons-material"
import styles from "./DictionaryRoute.module.scss"
import { useSwitchRoute } from "../../functions/functions"
import { DictionaryList } from "./DictionaryList/DictionaryList"

const DictionaryRoute = () => {
    const navigate = useSwitchRoute() 

    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <Button variant="outlined" className={styles.backButton} onClick={() => navigate("/")}>
                    <KeyboardArrowLeft />
                </Button>
                <Typography variant="h2">
                    Словарь
                </Typography>
            </div>
            <DictionaryList />
        </div>
    )
}

export {
    DictionaryRoute,
}