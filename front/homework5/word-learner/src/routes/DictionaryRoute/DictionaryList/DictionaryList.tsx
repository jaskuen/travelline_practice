import styles from "./DictionaryList.module.scss"
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { IconButton } from "@mui/material";
import { Reorder } from "@mui/icons-material";

type ActionsType = {
    name: string,
}

const createData = (
    russian: string,
    english: string,
    actions: ActionsType,
) => {
    return { russian, english, actions }
}

//const rows = ...      использование local storage
const rows = [
    createData('кот', 'cat', {name: "catt"}),
    createData('мяч', 'ball', {name: "balll"}),
    createData('машина', 'car', {name: "carr"}),
]

const DictionaryList = () => {
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
                        {rows.map((row) => (
                            <TableRow
                                key={row.russian}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {row.russian}
                                </TableCell>
                                <TableCell align="right">{row.english}</TableCell>
                                <TableCell align="right">
                                    <IconButton aria-label="more" onClick={() => {}}>
                                        <Reorder />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}

export {
    DictionaryList,
}