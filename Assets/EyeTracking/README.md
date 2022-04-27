# Tobii 眼動儀框架

## 使用說明
> 所有的範例都在本資料夾內的 `Scenes` 內，有兩個 scene，可以配合以下說明邊看

### 獲取參數
眼動儀參數都包裝在 `GazeManager`，無須引入任何東西，直接使用 `GazeManager.Instance` 即可使用，裡面包含以下資訊：
- `IsValid` 以下的這些值是否可用 (是否過期？)
- `IsGazing` 是否在注視螢幕？
- `GazePoint` 注視點 (螢幕座標)
- `IsFocusing` 是否注視帶有 Gaze Trigger 的可注視物件
- `HeadPosition` 使用者頭部位置
- `HeadRotation` 使用者頭部旋轉

### Trigger  
我把這個框架設計成事件驅動的概念，你可以把腳本附在任何一個 Game Object 上，並給它對應的動作。  

### Gaze Trigger
範例內的 Gaze 場景，背景、箭頭和文字都有 `GazeTrigger`，他們會在使用者 **是否有在觀看螢幕 (Gaze)** 觸發相對應的動作。 (你也可以把 GazeTrigger 綁在同一個物件上，方便管理)  

![](https://i.imgur.com/3tgfdv8.png)

### Focus Trigger
範例內的 Focus 場景則是將 Capsule 綁定了這個腳本，並利用使用者 **是否有注視這個物件 (Focus)** 觸發相對應的動作。  
(**需要注意的是，本腳本需要掛在被偵測的物件上，而且必須同時具有 GazeAware 和任意 Collider**。  
我幫你寫好檢查了：Collider 需要自己加上，GazeAware 在添加此腳本時會自動加上)  

![](https://i.imgur.com/adONWcS.png)


## 負責人
@jcxyis

