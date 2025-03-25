import parseHtml from "./lib/html-parser.js"
import getDiff from "./lib/json-diff.js"
import { Command } from "commander"

const program = new Command()

program.command('html-parse')
    .description("Parse html code and get all links")
    .argument('<string>', 'src to a html file to parse')
    .action((source) => {
        console.log(parseHtml(source))
    })

program.command('json-diff')
    .description("Compare two JSON-files")
    .argument('<string>', 'src to old JSON')
    .argument('<string>', 'src to new JSON')
    .action((src1, src2) => {
        console.log(getDiff(src1, src2))
    })

program.parse()
