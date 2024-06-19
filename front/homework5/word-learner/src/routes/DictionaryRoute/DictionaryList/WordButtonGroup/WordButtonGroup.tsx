import { Button, ButtonGroup } from "@mui/material"
import styles from "./WordButtonGroup.module.scss"
import { Delete, Edit } from "@mui/icons-material"
import { useNavigate } from "react-router-dom"
import { useWordStore } from "../../../../functions/functions"

type WordButtonGroupProps = {
    wordId: string,
}

const WordButtonGroup = (props: WordButtonGroupProps) => {
    const {
        wordId
    } = props
    const navigator = useNavigate()
    const {deleteWord} = useWordStore()
    const editWordRouteProps = { 
        state: { 
            id: wordId, 
        }}
    const buttons = [
        <Button 
            key="edit" 
            startIcon={<Edit />} 
            onClick={() => {
                navigator("/edit-word", editWordRouteProps)
            }}>Редактировать</Button>,
        <Button 
            key="delete" 
            startIcon={<Delete />} 
            onClick={() => {
                deleteWord(wordId)
            }}>Удалить</Button>
    ]
    return (
        <div className={styles.wrapper} >
            <ButtonGroup orientation="vertical" aria-label="Vertical button group">
                {buttons}
            </ButtonGroup>
        </div>
    )
}

export {
    WordButtonGroup,
}