# Mifare Magic Card Identifier

## Overview

<u>This software works with the **ACR122U** NFC Reader/Writer only!</u>

It retrieves and displays the **UID**, **BCC**, **SAK**, **ATQA** and **ATS** of your Mifare Classic 1k cards.

It also identifies the card's generation:
- **Gen1** UID LOCKED
- **Gen1A** UID Changeable (Backdoor)
- **Gen1B** UID Changeable (Backdoor)
- **Gen2** CUID

and indicates the state of the **access conditions** for Sector 0 (**locked** or **unlocked**).

## Usage

1. Connect the **ACR122U** NFC Reader/Writer.
2. Place a **Mifare Classic 1k card** on the reader.
3. Run the "**MifareMagicCardIdentifier.exe**" program to get the output information for this tag.
4. To scan a different tag, simply place the **new Mifare Classic 1k card** on the reader and press **Enter** to retrieve the new data.

## Screenshots

**MIFARE Classic (Gen1) aka UID Locked**

![Gen1_UID_Locked](docs/images/Gen1_UID_Locked.jpg)

**MIFARE Classic Gen1A aka UID Changeable with Backdoor**

![Gen1_UID_ReWritable](docs/images/Gen1_UID_ReWritable.jpg)

**MIFARE Classic DirectWrite aka Gen2 aka CUID**

![Gen2](docs/images/Gen2.jpg)
