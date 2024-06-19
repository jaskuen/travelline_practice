import styles from "./MainRoute.module.scss"
import { Button } from "@mui/material"
import { Typography } from "@mui/material"
import { useNavigate } from "react-router-dom"

const MainRoute = () => {
    const navigate = useNavigate()

    return (
        <div className={styles.wrapper}>
            <Typography variant="h1" >
                Выберите режим
            </Typography>
            <div className={styles.buttonsWrapper}>
                <Button variant="contained" onClick={() => navigate('/dictionary')}>Заполнить словарь</Button>
                <Button variant="outlined" onClick={() => navigate('/check')}>Проверить знания</Button>
            </div>   
        </div>
    )
}

export {
    MainRoute,
}