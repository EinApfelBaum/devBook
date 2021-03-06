---
created: 22.10.2021
tags: linux flatpak
parent: Linux
---

# Custom installation path

Two different option for a custom installation path.

1. Use the option `--user` when you install a flatpak package

    ```bash
    flatpak install --user --from http://ftp.fau.de/tdf/libreoffice/flatpak/LibreOffice.flatpakref
    ```

2. Configure a custom path. This path could be on a different partition.

    See description here [[linux-flatpak-custom-path-2]]

    For a faster installation and to prevent errors create an alias:

    ```bash
    fish alias
    alias myFlatpak="flatpak --installation=myFlatpaks install flathub"
    funcsave myFlatpak
    myFlatpak org.texstudio.TeXstudio
    ```

---

## Resources

* [https://github.com/flatpak/flatpak/issues/2337](https://github.com/flatpak/flatpak/issues/2337)
* [https://docs.flatpak.org/en/latest/tips-and-tricks.html#adding-a-custom-installation](https://docs.flatpak.org/en/latest/tips-and-tricks.html#adding-a-custom-installation)

[//begin]: # "Autogenerated link references for markdown compatibility"
[linux-flatpak-custom-path-2]: linux-flatpak-custom-path-2.md "Custom installation path 2"
[//end]: # "Autogenerated link references"