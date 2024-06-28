import { useLocation, useNavigate } from "react-router-dom"
import styles from "./ResultRoute.module.scss"
import { Button, Typography } from "@mui/material"
import { Book, CheckCircle, Error } from "@mui/icons-material"

const ResultRoute = () => {
    const navigator = useNavigate()
    const location = useLocation()
    const data = {
        result: location.state.result,
        wordsCount: location.state.wordsCount,
    }
    return (
        <div className={styles.wrapper}>
            <Typography variant="h2">Результат проверки знаний</Typography>
            <div className={styles.row} >
                <Typography variant="subtitle1">
                    <CheckCircle/>
                    Правильных: {data.result} 
                </Typography>
            </div>
            <div className={styles.row} >
                <Typography variant="subtitle1">
                    <Error/>
                    Ошибок: {data.wordsCount - data.result} 
                </Typography>    
            </div>
            <div className={styles.row} >
            <Typography variant="subtitle1">
                    <Book />
                    Всего слов: {data.wordsCount} 
                </Typography>    
            </div>
            <div className={styles.buttonsWrapper}>
                <Button variant="contained" onClick={() => navigator("/check")}>Проверить знания ещё раз</Button>
                <Button variant="outlined" onClick={() => navigator("/")}>Вернуться в начало</Button>
            </div>
        </div>
    )
}

export {
    ResultRoute,
}