# Rhino Insideをはじめよう
１．RhinoInsideRevitとは？

２．Grasshopperで利用してみる

３．C＃でRevitAPIを使う

４．独自プラグインを作ってみる　（次の回）

## Workshop対象者
* Revitを使える
* Rhinoを使える
* Rhino C# がわかる
* Grasshopper開発基礎がわかる

## PC環境
* Windows10
* Revit2020
* RhinoWIP
* VisualStudio2019
* Grasshopper templates for v6

## インストール
以下のリンクからRhino.Inside.RevitとRhino WIPをダウンロードしてください。
[Rhino.Inside.Revit](https://www.rhino3d.com/download/rhino.inside-revit/7/wip)
[Rhino WIP](https://www.rhino3d.com/download/rhino/wip)
Rhino WIPを先にインストールしてください。
次にRhino.Inside.Revitをインストールする。

[Grasshopper templates for v6](https://marketplace.visualstudio.com/items?itemName=McNeel.GrasshopperAssemblyforv6)

## Rhino.Inside.Revitとは？
[Rhino.Inside](https://github.com/mcneel/rhino.inside)は、Robert McNeel & Associatesが開発した新しい技術で、RhinoのWIPを他のアプリケーションに埋め込むことができます。Rhino.Insideは、様々な分野の多くのアプリケーションに組み込まれています。

Rhino.Inside.RevitはRhino.Insideの最も注目すべきプロジェクトの一つです。Autodesk Revit®のアドオンで、他のRevitアドオンと同様にRhinoのWIPをRevitのメモリ上に起動することができます。

Rhino.Inside.Revitは、Rhino WIPとGrasshopperの豊富な幾何学処理アルゴリズムをAutodesk Revit®環境で使用できます。

## Rhino.Inside.Revitをロードする

Autodesk Revit®を起動します。Rhino.Inside.Revitの読み込みを確認するよう求められます。今後このダイアログをスキップするには、必ず[常にロード]を押してください。

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/01_load.png" height="250" >


ロードが完了したら、アドインタブの下にある新しいRhinocerosのボタンが見つかります。

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/03_load.png" >


RhinoボタンをクリックしてRhino.Inside.Revitの読み込みを開始します。このアドオンは、Revitのメモリ内にRhino WIPをロードしようとし、ライセンスが取得されていることを確認します。ロード処理が完了すると、Revitに新しいRhinocerosツールバーが表示されます。

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/02_load.png">


新しいツールバーには、多くの新しいボタンが含まれており、以下の機能にアクセスすることができます。

RhinoのWIP自体
Python IDE (Revit APIにアクセス可能)
Grasshopper (カスタム Revit コンポーネントを使用)

Rhinocerosタブのボタンの全てのリストは[Rhino.Inside.Revit Interface](https://www.rhino3d.com/inside/revit/beta/reference/rir-interface)を参照してください。

## １．Rhino.Inside.Revitの基礎

1-1.Revitの要素の読み込み
<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/1-1_GetGeometryFromRevit.PNG">
1-2.RhinoのジオメトリをRevitへ受け渡す
<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/1-1_MeshGeometry.PNG">
## 2.Rhino.Inside.Revitの基礎GH

2-1.レベルを複数つくる

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/2-1_MakeLevel.PNG" height="300">

2-2.壁をつくる
<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/2-2_MakeWall.PNG">

2-3.Massから壁と床をつくる

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/3-1_Walls2.PNG" height="300">
<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/3-1_Walls.PNG" height="300">

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/3-1_Schedule.PNG">

## 3.Rhino.Inside.RevitのGH　C＃

3-1．まとめてｃ＃でつくる

まずC#コンポーネントを右クリックしてManage Assenblies...からReferenced　Assembliesを指定する

1. RevitAPIUI.dll

2. RevitAPI.dll

3. RhinoInside.Revit.dll

C:\Users\[UserName]\AppData\Roaming\Autodesk\Revit\Addins\2020\RhinoInside.Revit\RhinoInside.Revit.dll

C:\Program Files\Autodesk\Revit 2020\RevitAPI.dll

C:\Program Files\Autodesk\Revit 2020\RevitAPIUI.dll

<img src="https://github.com/yishizu/TokyoAECMeetup/blob/master/RhinoInsideRevitWorkshop/Images/3-1_ReferenceDlls.PNG">

```
using RIR = RhinoInside.Revit;
using DB = Autodesk.Revit.DB;
using UI = Autodesk.Revit.UI;

```


```
// make the sphere
_sphere = new Rhino.Geometry.Sphere(Rhino.Geometry.Point3d.Origin, (double) Radius);
// if requested, ask Rhino.Inside.Revit to run bake method
if ((bool) Trigger)
{
  RIR.Revit.EnqueueAction(CreateGeometry);
}

// pass the sphere to output
Sphere = _sphere;

```

```
private Rhino.Geometry.Sphere _sphere;

  private void CreateGeometry(DB.Document doc)
  {
    var brep = _sphere.ToBrep();

    var meshes = Rhino.Geometry.Mesh.CreateFromBrep(
      brep,
      Rhino.Geometry.MeshingParameters.Default
      );

    var revitCategory = new DB.ElementId((int) DB.BuiltInCategory.OST_GenericModel);

    var ds = DB.DirectShape.CreateElement(doc, revitCategory);

    foreach (var mesh in meshes){
      var geom = RIR.Convert.Geometry.GeometryEncoder.ToMesh(mesh);
      ds.SetShape(new DB.GeometryObject[] { geom });
    }
  }

```

## 参考
[Rhino.Inside.Revit Getting Started](https://www.rhino3d.com/inside/revit/beta/getting-started)
