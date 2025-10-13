# 🔹 PMLNet_1

Demonstrates the standard procedure for loading a C# DLL into AVEVA and using its class as a PML object.

# 🛠️ Setup Procedure

1. **Create a New Project**
   - Start a new **C# Class Library (.NET Framework)** project in Visual Studio.
   - Set the target framework to match the AVEVA version requirements.

2. **Add Assembly Attribute**
   - In `AssemblyInfo.cs`, add the following line:
     ```csharp
     [assembly: PMLNetCallable()]
     ```

3. **Make the Class PML Callable**
   - Decorate your class and its constructor with the `[PMLNetCallable()]` attribute:
     ```csharp
        namespace PMLNet_1
        {
            [PMLNetCallable()]
            public class MyPMLNet
            {
                [PMLNetCallable()]
                public MyPMLNet()
                {}
            }
        }
     ```

4. **Create a Callable Method**
   - Define a method (e.g., `Assign`) and mark it with the `PMLNetCallable` attribute.
   - Add a `MessageBox.Show()` call or any logic to verify execution:
     ```csharp
        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        {}
        
        [PMLNetCallable()]
        public void Start()
        {
            MessageBox.Show("Hii First MyPmlNet is Working");
        }
     ```

5. **Build the Project**
   - Compile the DLL in **Debug** or **Release** mode.

6. **Deploy the DLL**
   - Copy the compiled DLL to the appropriate AVEVA installation directory or a path accessible by the AVEVA application.

---

## 🧪 Debugging

1. Launch AVEVA (e.g., E3D).
2. In Visual Studio, go to **Debug > Attach to Process**.
3. Select the AVEVA process (e.g., `mod.exe` depends on which module you are testing) and attach the debugger.
4. Set breakpoints in your code.
5. Trigger your method from PML to hit the breakpoints.

---

## 💡 Using the DLL in PML

1. Open the **Command Window** in AVEVA.
2. Import the DLL and reference its namespace:
    ```pml
    import 'PMLNet_1'
    using namespace 'PMLNet_1'
    ```
3. Create an instance of the class:
    ```pml
    !MyPMLNet		= object MyPMLNet()
    !MyPMLNet.Start()
    ```
4. Call the method:
    ```pml
    !MyPMLNet.Start()
    ```

## 📁 Additional Notes

- Ensure the DLL path and namespace are correctly configured in PML.
- Folder structure may need to match AVEVA’s expectations for macro loading.
- These macros may have been developed by Initiec, not Ticodi—so compatibility between Initiec and Ticodi code should be validated.
- If unsure about the macro logic or setup, consult with your CAD/System team for guidance.

## 📞 Support
For setup issues or debugging help, please contact your AVEVA system administrator or the development team responsible for macro integration.