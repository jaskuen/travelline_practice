import { parse, HTMLElement } from "node-html-parser"
import fs from 'node:fs'

const parseHtml = (source) => {
    const documentToParse = fs.readFileSync(source, {encoding: "utf-8"})
    const parsed = parse(documentToParse).querySelectorAll("[src],[href]")
    return parsed.map(elem => elem.attributes.src || elem.attributes.href)
}

export default parseHtml