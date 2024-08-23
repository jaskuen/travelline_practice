import { Button, Typography } from "@mui/material"
import { KeyboardArrowLeft } from "@mui/icons-material"
import styles from "./DictionaryRoute.module.scss"
import { DictionaryList } from "./DictionaryList/DictionaryList"
import { useNavigate } from "react-router-dom"

const DictionaryRoute = () => {
    const navigate = useNavigate()

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
            <Button className={styles.addButton} variant="contained" onClick={() => navigate("/new-word")}>+ДОБАВИТЬ СЛОВО</Button>
            <DictionaryList />
        </div>
    )
}

export {
    DictionaryRoute,
}