import { parse, HTMLElement } from "node-html-parser"
import fs from 'node:fs'

const parseHtml = (source: string): Array<string> => {
    const documentToParse: string = fs.readFileSync(source, {encoding: "utf-8"})
    const parsed: HTMLElement[] = parse(documentToParse).querySelectorAll("[src],[href]")
    return parsed.map(elem => elem.attributes.src || elem.attributes.href)
}

export default parseHtml