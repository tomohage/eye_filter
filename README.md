# eye_filter
eyetribeを用いた視線情報をリアルタイムで画面上に載せるためのフィルタです。  
MVCモデルに近い構成で作成した。  
Viewはフォームアプリケーションのデザイン、ControllerはViewで発生したイベントに対して処理を実行し、  
ModelはViewで入力した値を保存する。  
ModelファイルのほかにModelServiceファイルがあり、複雑な処理やViewの操作を行う。  
  
* Eyetribe_Project/Models/
 * [フォーム名]Model.cs  
 フォームに入力した値や、Viewクラスインスタンスを保存するモデルメソッド  
 * [フォーム名]ModelService.cs  
 Modelでは行わない複雑な処理やViewへの更新処理を行うメソッド  
 [フォーム名]Modelクラスは部分クラスで、このファイルのクラスも[フォーム名]Modelクラスの部分クラスである  
* Eyetribe_Project/Views/
 * [フォーム名].cs
 フォームのControllerファイル
 * [フォーム名].Designer.cs
 フォームのViewファイル
