# 🚀 C# PMLNet Examples

This repository provides a curated set of examples for customizing **AVEVA** applications using **C#** via **PMLNet**. It demonstrates how to build dynamic link libraries (DLLs), integrate them with AVEVA modules, and enable seamless data exchange between **C#** and **PML (Plant Modeling Language)**.

---

## 📘 Overview

Each project includes a `MyPMLNet.cs` class containing the core C# logic, compiled into a class library. These libraries are consumed by AVEVA through corresponding **PML scripts** located in the `pmllib` folder.

To run the examples:

- Place the compiled DLLs and `pmllib` folder inside the AVEVA installation directory.
- Run `PML Rehash all` to make pmllib code available to AVEVA for reading.
- The PML scripts invoke C# methods as PML objects, enabling powerful customization and automation.

---

## 📂 Table of Contents

### [🔹 PMLNet_1](./PMLNet/PMLNet_1/README.md)
Demonstrates the standard procedure for loading a C# DLL into AVEVA and using its class as a PML object.

### [🔹 PMLNet_2](./PMLNet/PMLNet_2/README.md)
Explores data transfer between PML and C#, including effective type mapping and conversion strategies.

### [🔹 PMLNet_3](./PMLNet/PMLNet_3/README.md)
Showcases method assignment and overriding in C# for use within PML scripts.

### [🔹 PMLNet_4](./PMLNet/PMLNet_4/README.md)
Implements custom error handling and event-driven programming using C# delegates.

### [🔹 PMLNet_5](./PMLNet/PMLNet_5/README.md)
Illustrates how PML objects can be accessed and manipulated from C#, with practical examples.

---

## 🤝 Contributing

This repository is open-source and welcomes contributions! If you have ideas, enhancements, or additional examples to share, feel free to:

- Fork the repo
- Create a new branch
- Submit a pull request

Let's build a stronger AVEVA customization community together.

---

## 📬 Contact

For questions, suggestions, or collaboration opportunities, please open an issue or start a discussion on GitHub.

---