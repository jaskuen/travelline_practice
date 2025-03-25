# 1 Основы, Typescript, окружение

## Домашнее задание

Домашнее задание состоит из двух уровней сложности. Переходить ко второму уровню следует только после реализации первого
уровня. Для реализации следует изучить и использовать npm пакеты <https://www.npmjs.com/package/commander> и
<https://www.npmjs.com/package/node-html-parser>

### 1 уровень

Реализовать консольное приложение 1-tools.js с командой _html-resources_, которое выводит все ссылки к ресурсам,
найденныей в html-файле, путь к которому передаётся как входное значение.

Пример выполнения команды:

```
node 1-tools.js html-resources ../fixtures/html-parser/index.html
[
  "./style.css",
  "./favicon.ico",
  "https://www.google.com",
  "/media/cc0-images/grapefruit-slice-332-332.jpg",
  "https://www.example.com",
  "app.js",
  "vendor.js",
];
```

index.html при этом имеет следующий вид:

```
<!doctype html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>My Website</title>
    <link rel="stylesheet" href="./style.css" />
    <link rel="icon" href="./favicon.ico" type="image/x-icon" />
  </head>
  <body>
    <main>
      <h1>Welcome to My Website</h1>
      <p>My first paragraph with <a href="https://www.google.com">link</a>.</p>
      <p>My second paragraph with <a href="https://www.google.com">the same link</a>.</p>
      <img src="/media/cc0-images/grapefruit-slice-332-332.jpg" alt="Grapefruit slice atop a pile of other slices" />
      <p>My third paragraph with <a href="https://www.example.com">link to example</a>.</p>
    </main>
    <script src="app.js"></script>
    <script src="vendor.js"></script>
  </body>
</html>
```

### 2 уровень

Добавить к приложению из первого уровня команду _json-diff_, которое выводит разницу между двумя json файлами. Должен
выводится статусу по каждому свойству: удалено, добавлено, изменено, не изменено.

Пример выполнения команды:

```
node 1-tools.js json-diff ../fixtures/json-diff/simple/old.json ../fixtures/json-diff/simple/new.json
{
  "timeout": {
    "type": "changed",
    "oldValue": 20,
    "newValue": 50
  },
  "verbose": {
    "type": "delete",
    "oldValue": true
  },
  "host": {
    "type": "unchanged",
    "oldValue": "google.com",
    "newValue": "google.com"
  },
  "proxy": {
    "type": "new",
    "newValue": "888.888.88.88"
  }
}
```

old.json

```
{
  "timeout": 20,
  "verbose": true,
  "host": "google.com"
}
```

new.json

```
{
  "timeout": 50,
  "proxy": "888.888.88.88",
  "host": "google.com"
}
```

Пример с вложенными объектами:

old.json

```
{
  "common": {
    "setting1": "Value 1",
    "setting2": "200",
    "setting3": true,
    "setting6": {
      "key": "value"
    }
  },
  "group1": {
    "baz": "bas",
    "foo": "bar"
  },
  "group2": {
    "abc": "12345"
  }
}
```

new.json

```
{
  "common": {
    "setting1": "Value 1",
    "setting3": true,
    "setting4": "blah blah",
    "setting5": {
      "key5": "value5"
    }
  },
  "group1": {
    "foo": "bar",
    "baz": "bars"
  },
  "group3": {
    "fee": "100500"
  }
}
```

output

```
{
  "common": {
    "type": "changed",
    "children": {
      "setting1": {
        "type": "unchanged",
        "oldValue": "Value 1",
        "newValue": "Value 1"
      },
      "setting2": {
        "type": "delete",
        "oldValue": "200"
      },
      "setting3": {
        "type": "unchanged",
        "oldValue": true,
        "newValue": true
      },
      "setting6": {
        "type": "delete",
        "oldValue": {
          "key": "value"
        }
      },
      "setting4": {
        "type": "new",
        "newValue": "blah blah"
      },
      "setting5": {
        "type": "new",
        "newValue": {
          "key5": "value5"
        }
      }
    }
  },
  "group1": {
    "type": "changed",
    "children": {
      "baz": {
        "type": "changed",
        "oldValue": "bas",
        "newValue": "bars"
      },
      "foo": {
        "type": "unchanged",
        "oldValue": "bar",
        "newValue": "bar"
      }
    }
  },
  "group2": {
    "type": "delete",
    "oldValue": {
      "abc": "12345"
    }
  },
  "group3": {
    "type": "new",
    "newValue": {
      "fee": "100500"
    }
  }
}
```

Пример с одинаковыми объектами (которые содержат массив)

old.json и new.json одинаковые

```
{
  "Title": "Interstellar",
  "prop1": {
    "Year": "2014",
    "prop2": {
      "Rated": "PG-13",
      "prop3": {
        "Actors": ["Ellen", "Matthew", "Mackenzie Foy", "John"]
      }
    }
  }
}
```

output

```
{
  "Title": {
    "type": "unchanged",
    "oldValue": "Interstellar",
    "newValue": "Interstellar"
  },
  "prop1": {
    "type": "unchanged",
    "children": {
      "Year": {
        "type": "unchanged",
        "oldValue": "2014",
        "newValue": "2014"
      },
      "prop2": {
        "type": "unchanged",
        "children": {
          "Rated": {
            "type": "unchanged",
            "oldValue": "PG-13",
            "newValue": "PG-13"
          },
          "prop3": {
            "type": "unchanged",
            "children": {
              "Actors": {
                "type": "unchanged",
                "children": {
                  "0": {
                    "type": "unchanged",
                    "oldValue": "Ellen",
                    "newValue": "Ellen"
                  },
                  "1": {
                    "type": "unchanged",
                    "oldValue": "Matthew",
                    "newValue": "Matthew"
                  },
                  "2": {
                    "type": "unchanged",
                    "oldValue": "Mackenzie Foy",
                    "newValue": "Mackenzie Foy"
                  },
                  "3": {
                    "type": "unchanged",
                    "oldValue": "John",
                    "newValue": "John"
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}
```

Пример: был примитивный тип, а стал объект

old.json

```
{
  "common": {
    "setting1": "Value 1",
    "setting3": true,
    "setting4": "blah blah",
    "setting5": {
      "key5": "value5"
    }
  }
}
```

new.json

```
{
  "common": {
    "setting1": "Value 1",
    "setting3": {
      "foo": "bar",
      "baz": "bars",
      "group3": {
        "fee": "100500"
      }
    },
    "setting4": "blah blah",
    "setting5": 1234
  }
}
```

output

```
{
  "common": {
    "type": "changed",
    "children": {
      "setting1": {
        "type": "unchanged",
        "oldValue": "Value 1",
        "newValue": "Value 1"
      },
      "setting3": {
        "type": "changed",
        "oldValue": true,
        "newValue": {
          "foo": "bar",
          "baz": "bars",
          "group3": {
            "fee": "100500"
          }
        }
      },
      "setting4": {
        "type": "unchanged",
        "oldValue": "blah blah",
        "newValue": "blah blah"
      },
      "setting5": {
        "type": "changed",
        "oldValue": {
          "key5": "value5"
        },
        "newValue": 1234
      }
    }
  }
}
```

## Полезные ссылки

1. https://learn.javascript.ru/intro
2. https://doka.guide/tools/static-types/
3. https://scriptdev.ru/guide/007/
4. https://frontender.info/const-immutability/
5. https://www.typescriptlang.org/docs/handbook/enums.html#objects-vs-enums
6. https://www.typescriptlang.org/docs/handbook/2/everyday-types.html#union-types
7. https://learn.javascript.ru/types
8. https://learn.javascript.ru/object
9. https://doka.guide/tools/nodejs/
10. https://doka.guide/tools/nodejs-tooling/
11. https://doka.guide/tools/package-managers/
12. https://ru.hexlet.io/courses/javascript_setup/lessons/npm/theory_unit
13. https://learn.javascript.ru/array-methods
14. https://learn.javascript.ru/import-export
