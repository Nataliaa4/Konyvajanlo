# Könyvajánló

## Csapattagok
- Léh Natália Szilvia
- Pölös Bettina

## Választott téma
Könyvajánló – tematikus gyűjtemény könyvekről, kedvenc könyvek kiemelésével.

## Adatmodell
A projekt fő adatosztálya a **Book**, amely az alábbi mezőket tartalmazza:  
- **Id** (int) – Egyedi azonosító  
- **Title** (string) – Könyv címe  
- **Author** (string) – Szerző neve  
- **Category** (string) – Kategória / műfaj  
- **Description** (string) – Rövid leírás  
- **Rating** (int) – Értékelés 1–10  
- **Year** (int) – Kiadás éve  
- **IsFavorite** (bool) – Kedvenc könyv jelölése  

## A program funkciói
- Új könyv hozzáadása  
- Könyvek listázása  
- Keresés cím alapján  
- Szűrés kategória szerint  
- Rendezés (pl. Értékelés vagy Év szerint)  
- CSV import és export  
- HTML export (index.html, items.html, favorites.html)  

## Generált oldalak
- **index.html** – Főoldal, projekt címe, rövid leírás, statisztikák, néhány kiemelt könyv  
- **items.html** – Összes könyv listája táblázatban/kártyákban, kategóriával, rövid leírással  
- **favorites.html** – Kedvenc könyvek listája, csak azok, ahol `IsFavorite == true`  

## Rövid képernyőképek
![Főoldal](images/index_index.png)  
![Összes könyv](images/items_items.png)  
![Kedvencek](images/favorites_favourites.png)
