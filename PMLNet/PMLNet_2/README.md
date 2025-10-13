# 🔹 PMLNet_2

Explores data transfer between PML and C#, including effective type mapping and conversion strategies.

## 🛠️ **Setup Procedure**

Follow the same initialization steps as in the `PMLNet_1` project to set up a new, fresh **Class Library project** named `PMLNet_2`.
Once the basic PMLNet structure is ready, proceed with the examples below to define and test various callable scenarios between **PML** and **C#**.

---

### 🧮 **Define Sample Variables in PML**

Before executing the examples, define the following PML variables:

```pml
!p[1] = 1.2
!p[2] = 2.4
!p[4] = 2.4
!MyPMLNet = object MyPMLNet()
```

---

## ⚙️ **Examples and Use Cases**

### **1. Passing Boolean Values**

Transfer boolean variables directly from PML and C# and returning back the same to PML.

```csharp
[PMLNetCallable()]
public bool MyBool(bool value)
{
    return value;
}
```

**PML Usage:**

```pml
!MyBool = !MyPMLNet.MyBool(True)
q var !MyBool
```

---

### **2. Passing and Returning Strings Between PML and C#**

Demonstrates basic string communication between both environments same like `bool`.

```csharp
[PMLNetCallable()]
public string MyString(string text)
{
    return text;
}
```

**PML Usage:**

```pml
!myString = !MyPMLNet.MyString(|Shivang|)
q var !myString
```

---


### **3. Full Property Definition Example**

Expose a property to be accessed directly from PML.

```csharp
[PMLNetCallable()]
public string VarString { get; set; }
```

**PML Usage:**

```pml
!MyPMLNet.VarString(|Hi|)
!VarString = !MyPMLNet.VarString()
q var !VarString
```

---

### **4. Passing PML Real Values to a C# Method**

Demonstrates how to transfer numerical (Real) variables from PML to C# and return the sum of those variables as PML Real.

```csharp
[PMLNetCallable()]
public double DoubleSum(double p, double q)
{
    return (p + q);
}
```

**PML Usage:**

```pml
!DoubleSum = !MyPMLNet.DoubleSum(!p[1], !p[2])
q var !DoubleSum
```

---

### **5. Method Overloading: Passing a PML Array to C#**

A PML array is automatically converted to a `Hashtable` in C#.

```csharp
[PMLNetCallable()]
public double DoubleSum(Hashtable items)
{
    double sum = 0;
    foreach (DictionaryEntry entity in items)
    {
        sum += (double)entity.Value;
    }
    return sum;
}
```

**PML Usage:**

```pml
!DoubleSum = !MyPMLNet.DoubleSum(!p)
q var !DoubleSum
```

---

### **6. Returning an Array (Hashtable) from C# to PML**

You can return a new hashtable from C# which will be interpreted as an array in PML.

```csharp
[PMLNetCallable()]
public Hashtable IndexHashtable(Hashtable items)
{
    Hashtable indexHashtable = new Hashtable();
    int index = 1;
    foreach (DictionaryEntry entity in items)
    {
        indexHashtable[index] = (double)entity.Key;
        index++;
    }
    return indexHashtable;
}
```

**PML Usage:**

```pml
!arrayIndex = !MyPMLNet.IndexHashtable(!p)
q var !arrayIndex
```

---

### **7. Modifying Variables Directly via Memory Reference**

By using the `ref` keyword, changes in C# directly modify the PML variable in memory.

```csharp
[PMLNetCallable()]
public void ReplaceHashtable(ref Hashtable items)
{
    Hashtable indexHashtable = new Hashtable();
    int index = 1;
    foreach (DictionaryEntry entity in items)
    {
        indexHashtable[index] = (double)entity.Key;
        index++;
    }
    items = indexHashtable;
}
```

**PML Usage:**

```pml
!MyPMLNet.ReplaceHashtable(!p)
q var !p
```

---

### **8. Passing Custom C# Objects from PML**

Illustrates how to send C# objects from PML and invoke their methods. `ShowMessageBox` is an class defined in `C#`.

```csharp
[PMLNetCallable()]
public void ShowMsgBox(ShowMessageBox messageBox)
{
    messageBox.ShowMsgBox();
}
```

**PML Usage:**

```pml
!ShowMessageBox = object ShowMessageBox()
!ShowMessageBox.Show(false)
!MyPMLNet.ShowMsgBox(!ShowMessageBox)
!ShowMessageBox.Show(true)
!MyPMLNet.ShowMsgBox(!ShowMessageBox)
```

---
