# hangman

================= LICENSE =================

Copyright (c) 2020 by Felipe de Moraes Modesto

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS.
IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS,
WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

================= DESCRIPTION =================

This project includes a fully functional Hangman game implemented in Unity 2019.3.3f1.

The current graphics in the game are simple.
The game architecture is divided into two layers: Business Layer and Gameplay Layer connected by an "API".
Game Rules and content are stored in scriptable objects with the explicit purposes of making it easier for designers to update content
as well as to simplify their integration into Addressable Assets for remote content updates.
The game's UI has been tested in the new Simulator package for various aspect ratios & screen sizes.
Debugging with Unity's Simulator package was made on a Nexus 4 as well as on a Pixel 3.
Theoretical iOS compatibility testing was made on an iPhone 6 simulator configuration.

The game was designed to be played in Portrait mode as the custom virtual keyboard usa feels more natural in this mode

NOTE: The included project is NON-FUNCTIONAL as the Sirenix Odin Inspector plugin is not bundled with the available code. Please import this plugin to your project.