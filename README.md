# AntiCorruptionLayerDemo
練習情境
既有系統有程式可以提供系統參數, 傳回的字串, 可能是項目的集合,或用json格式表示

缺點是各程式取回之後, 需要切額並轉換成集合, 或將字串反序列化,並轉成需要的物件型別

在 DDD 書籍講述防腐層的作法, 應該可以適用這個情境, 所以做了練習

解決方式
1. 先用 Facade pattern 向既有系統取得系統參數值, 日後取用方式若改變, 就修改這裡
2. 寫 Adapter object 绸 Facade 物件傳回資訊轉換成需要的集合格式, 日後如果 Facade object傳來的格式改變, 就加寫 Adapter object, 就仍能傳回相同型別的結果
3. 在新系統的 Service object 叫用 Adapter 物件便能取得新系統需要的格式, 在這裡叫的是 interface, 日後要抽換 adapter 不必修改程式, 用 DI 來決定
4. 新系統只要叫用 Service object 就能取得系統參數了
