# Mifare Magic Card Identifier (MMCI)

## Overview

**Mifare Magic Card Identifier (MMCI)** supports **[ACR122U](https://skylandersnfc.github.io/Docs/Skylanders_Buying_List/Skylanders_NFC_Devices/#acr122u-all-skylanders)** and **[PN532 V2.0](https://skylandersnfc.github.io/Docs/Skylanders_Buying_List/Skylanders_NFC_Devices/#pn532-v20-all-skylanders)** NFC devices.

It retrieves and displays the **UID**, **BCC**, **SAK**, **ATQA** and **ATS** of your Mifare Classic 1k cards.

It also identifies the card's generation:
- **Gen1** UID LOCKED
- **Gen1A** UID Changeable (Backdoor)
- **Gen1B** UID Changeable (Backdoor)
- **Gen2** CUID

and indicates the state of the **access conditions** for Sector 0 (**locked** or **unlocked**).

## Usage

1. Download the **correct** **[Mifare-Magic-Card-Identifier](https://github.com/skylandersNFC/Mifare-Magic-Card-Identifier/releases)** archive for your NFC device and **extract it**.
2. Connect the **[ACR122U](https://skylandersnfc.github.io/Docs/Skylanders_Buying_List/Skylanders_NFC_Devices/#acr122u-all-skylanders)** or **[PN532 V2.0](https://skylandersnfc.github.io/Docs/Skylanders_Buying_List/Skylanders_NFC_Devices/#pn532-v20-all-skylanders)** NFC device.
3. Place a **Mifare S50 1k card** onto the reader.
4. Run the "**Mifare-Magic-Card-Identifier-XXXX.exe**" program to get the output information for this tag.
5. To scan a different tag, simply place the **new Mifare S50 1k card** on the reader and press **Enter** to retrieve the new data.

## Screenshots

**MIFARE Classic (Gen1) aka UID Locked**

![Gen1_UID_Locked](docs/images/Gen1_UID_Locked.jpg)

**MIFARE Classic Gen1A aka UID Changeable with Backdoor**

![Gen1_UID_ReWritable](docs/images/Gen1_UID_ReWritable.jpg)

**MIFARE Classic DirectWrite aka Gen2 aka CUID**

![Gen2](docs/images/Gen2.jpg)

> [!NOTE]
> The two values for SAK and ATQA represent the "Wake-Up" (first value) and "Block 0" (second value in brackets) swapping.
> The "Wake-Up" value is programmed into the card by the manufacturer, while the "Block 0" value is derived from the data dump stored on the tag.
> For example: `ATQA: 0004 (0F01)`. `0004` is "Wake-Up", `0F01` is "Block 0". More info here: [Mifare Classic - SAK Swapping Explained](https://gist.github.com/equipter/3022aea4e371e585ff6e46de637e7769)
