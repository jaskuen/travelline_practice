import { Command } from "commander"
import parseHtml from "./lib/html-parser"

const program = new Command()

program
    .command('html-parse')
    .argument('<fileSrc>', 'file src to parse')
    .action((fileSrc) => {
        console.log(parseHtml(fileSrc));
    })

program.parse()