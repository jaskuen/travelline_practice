import styles from "./DictionaryList.module.scss"
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { IconButton, Popper } from "@mui/material";
import { Reorder } from "@mui/icons-material";
import { useEffect, useState } from "react";
import { WordButtonGroup } from "./WordButtonGroup/WordButtonGroup";
import { useWordStore } from "../../../functions/functions";
import { WordType } from "../../../types/types";

const createData = (
    id: string,
    russian: string,
    english: string,
) => {
    return { id, russian, english }
}

const DictionaryList = () => {
    const {words} = useWordStore()
    const [rows, setRows] = useState<Array<WordType>>([])
    const [openedPopperId, setOpenedPopperId] = useState<string | null>(null)

    const handleClick = (wordId: string) => {
        setOpenedPopperId(openedPopperId === wordId ? null : wordId)
    }

    useEffect(() => {
        setRows(words.map(word => 
            createData(
                word.id, 
                word.russian, 
                word.english,
            )))
    }, [words])
    return (
        <div className={styles.wrapper}>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Слово на русском языке</TableCell>
                            <TableCell align="right">Перевод на английский язык</TableCell>
                            <TableCell align="right">Действие</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row) => {
                            
                            return (
                                <TableRow
                                    key={row.id}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell component="th" scope="row">
                                        {row.russian}
                                    </TableCell>
                                    <TableCell align="right">{row.english}</TableCell>
                                    <TableCell align="right" className={styles.iconButton}>
                                        <IconButton id={row.id} aria-label="more" onClick={() => handleClick(row.id)}>
                                            <Reorder />
                                        </IconButton>
                                        {openedPopperId === row.id && (
                                            <Popper open={true} anchorEl={document.getElementById(row.id)}>
                                                <WordButtonGroup wordId={row.id}/>
                                            </Popper>
                                        )}
                                    </TableCell>
                                </TableRow>
                            )})}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}

export {
    DictionaryList,
}