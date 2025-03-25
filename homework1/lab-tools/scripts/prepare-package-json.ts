import fs from "fs";
import path from "path";

const buildDir = "./dist";
const packageJsonFile = path.join(buildDir, "/package.json");

if (!fs.existsSync(packageJsonFile)) {
  fs.writeFileSync(packageJsonFile, new Uint8Array(Buffer.from('{"type": "module"}')));
}
