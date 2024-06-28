import {joinClassName} from "../../../public/functions"
import styles from "./TextBlock.module.css"

type TextBlockProps = {
    id: string,
    text: string,
}
const TextBlock = (props: TextBlockProps) => {
    const {
        id, 
        text,
    } = props;
    
    return (
        <>
            <div className={joinClassName(id, styles.textBlock)}>
                {text}
            </div>
        </>
    )
} 

export {
    TextBlock,
}

export type {
    TextBlockProps,
}