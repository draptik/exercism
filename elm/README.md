# Elm setup

- `yay -S elm-platform-bin`

## Within each project

- `npm init -y`
- `npm install --save-dev elm-test`
- `npm install --save-dev elm-format`

or just copy the `setup.sh` to the top-level folder and run it.

## Run tests

- `npx elm-test`

If you don't have `npx` installed, run `./node_modules/.bin/elm-test` instead.

Watcher can be started with `npx elm-test --watch`

