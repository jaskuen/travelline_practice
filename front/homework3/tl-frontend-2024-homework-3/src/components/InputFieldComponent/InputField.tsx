import { joinClassName } from "../../../public/functions"
import styles from "./InputField.module.css"

type InputFieldProps = {
    id: string
    type: 'name' | 'feedback'
    name?: string
    defaultValue?: string
    onChange: (s: string) => void
}
const InputField = (props: InputFieldProps) => {
    const {
        id,
        type,
        name,
        onChange,
        defaultValue
    } = props;

    const handleChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        onChange(event.target.value)  
    }

    return (
        <div className={joinClassName(styles.wrapper, type == 'name' ? "" : styles.feedback)}>
            {name 
                ? <div className={styles.name}>
                    {name}
                </div> 
                : null}
            <textarea 
                wrap={type == 'name' ? "off" : "on"}
                className={joinClassName(id, styles.inputField)} 
                placeholder={defaultValue ? defaultValue : undefined}
                onChange={handleChange} 
            />
        </div>
    )
}

export {
    InputField,
}

export type {
    InputFieldProps,
}