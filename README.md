# ExtendedCasinoBets Mod
Work in Progress (WIP)

A MelonLoader mod for enhancing casino betting options in Schedule I. Currently supports custom bet amounts for Blackjack and Slot Machines, with plans to expand functionality.

## Features
- Custom Blackjack Bets: Use F3 (decrease) and F4 (increase) to cycle through predefined bet amounts
- Custom Slot Machine Bets: Overrides default slot machine bet amounts with the same custom values as Blackjack.

## Installation
1. Ensure you have MelonLoader installed for your game.
2. Place the downloaded `ExtendedCasinoBets.dll` from the Releases tab into your game's mods folder
3. Launch the game and check the MelonLoader console for logs confirming the mod has started.

## Usage
- Blackjack: While in a Blackjack game, press:
  - `F3` to decrease your bet.
  - `F4` to increase your bet.

- Slot Machines: Custom bet amounts are automatically applied on game start.

## TODO
- Hook Slider: Replace F3/F4 key bindings with the normal slider input by hooking it
- Hook RTB game
- Hook Slot Machine Text: Modify slot machine text display to handle larger bet sizes.

## Known Issues
- Error handling is basic; unexpected exceptions may occur if the game’s Il2Cpp structure changes.
- Limited to Blackjack and Slot Machines for now.

## License
This project is unlicensed for now (WIP). Feel free to use or modify it for personal use.
