namespace ChestCounter;

/// <summary>
/// The page of the graphical interface: one HTML file (styles and script inside), drawn by the script from the state
/// the counter sends (<see cref="GuiServer"/>). Texts come with the state, in the chosen language.
/// </summary>
public static class GuiPage
{
    /// <summary>Every text of the page, in the chosen language.</summary>
    public static Dictionary<string, string> Texts() => new()
    {
        ["home"] = L.T("Accueil", "Home", "Inicio", "ホーム"),
        ["history"] = L.T("Historique", "History", "Historial", "履歴"),
        ["report"] = L.T("Rapport", "Report", "Informe", "レポート"),
        ["histIntro"] = L.T("Toutes les parties comptées du profil affiché. Le crayon corrige les coffres d'une partie ou la supprime ; une partie supprimée sort de tous les totaux et peut être restaurée.",
            "Every counted match of the profile shown. The pencil corrects a match's chests or deletes it; a deleted match leaves every total and can be restored.",
            "Todas las partidas contadas del perfil mostrado. El lápiz corrige los cofres de una partida o la elimina; una partida eliminada sale de todos los totales y se puede restaurar.",
            "表示中のプロフィールで集計したすべての試合です。鉛筆ボタンで試合ごとの宝箱数を補正したり、試合を削除したりできます。削除した試合はすべての合計から除かれ、あとで元に戻せます。"),
        ["avgTime"] = L.T("Durée moyenne d'une partie", "Average match time", "Duración media de una partida", "平均試合時間"),
        ["perMinute"] = L.T("{0} coffres par minute", "{0} chests per minute", "{0} cofres por minuto", "1分あたり {0} 個"),
        ["perMinuteLabel"] = L.T("coffres par minute", "chests per minute", "cofres por minuto", "1分あたりの宝箱"),
        ["perMatchLabel"] = L.T("coffres par partie", "chests per match", "cofres por partida", "1試合あたりの宝箱"),
        ["colDate"] = L.T("Date", "Date", "Fecha", "日時"),
        ["colMode"] = L.T("Mode", "Mode", "Modo", "モード"),
        ["colPlace"] = L.T("Place", "Placement", "Puesto", "順位"),
        ["colTime"] = L.T("Durée", "Time", "Duración", "試合時間"),
        ["colChests"] = L.T("Coffres", "Chests", "Cofres", "宝箱"),
        ["colEff"] = L.T("Coffres/min", "Chests/min", "Cofres/min", "効率（個/分）"),
        ["editMatch"] = L.T("Modifier cette partie", "Edit this match", "Modificar esta partida", "この試合を編集"),
        ["deleteMatch"] = L.T("Supprimer cette partie", "Delete this match", "Eliminar esta partida", "この試合を削除"),
        ["deleteConfirm"] = L.T("Supprimer cette partie de l'historique ? Elle sort du total, des moyennes et du rapport. Tu peux la restaurer dans « Parties supprimées », en bas de l'onglet Historique.",
            "Delete this match from the history? It leaves the total, the averages and the report. You can restore it in \"Deleted matches\", at the bottom of the History tab.",
            "¿Eliminar esta partida del historial? Sale del total, de las medias y del informe. Puedes restaurarla en «Partidas eliminadas», al final de la pestaña Historial.",
            "この試合を履歴から削除しますか？合計・平均・レポートから除かれます。履歴タブの下にある「削除した試合」からいつでも元に戻せます。"),
        ["counted"] = L.T("Comptés dans le replay : {0}", "Counted in the replay: {0}", "Contados en la repetición: {0}", "リプレイで数えた数: {0}"),
        ["byHandMatch"] = L.T("Corrigés à la main : {0}", "Changed by hand: {0}", "Corregidos a mano: {0}", "手動補正: {0}"),
        ["matchTotal"] = L.T("Total de la partie : {0}", "Match total: {0}", "Total de la partida: {0}", "この試合の合計: {0}"),
        ["effLine"] = L.T("Efficacité : {0}", "Efficiency: {0}", "Eficiencia: {0}", "効率: {0}"),
        ["adjustHelp"] = L.T("Le nombre tapé s'ajoute aux coffres de la partie (un nombre négatif en retire). La correction est gardée si le replay est réanalysé.",
            "The number typed is added to the match's chests (a negative number removes some). The change is kept if the replay is analyzed again.",
            "El número escrito se suma a los cofres de la partida (un número negativo quita cofres). La corrección se conserva si la repetición se analiza de nuevo.",
            "入力した数がこの試合の宝箱に加算されます（マイナスの数で減らせます）。リプレイを再解析しても補正は保持されます。"),
        ["resetAdjust"] = L.T("Revenir au nombre du replay", "Back to the replay's count", "Volver al número de la repetición", "リプレイの数に戻す"),
        ["deleted"] = L.T("Parties supprimées", "Deleted matches", "Partidas eliminadas", "削除した試合"),
        ["deletedHelp"] = L.T("Elles ne sont plus comptées, même quand leur replay est relu.", "They are no longer counted, even when their replay is read again.", "Ya no se cuentan, aunque su repetición se vuelva a leer.", "リプレイを読み直しても再集計されません。"),
        ["restore"] = L.T("Restaurer", "Restore", "Restaurar", "元に戻す"),
        ["deletedOn"] = L.T("supprimée le {0}", "deleted {0}", "eliminada el {0}", "{0} に削除"),
        ["chestsN"] = L.T("{0} coffres", "{0} chests", "{0} cofres", "宝箱 {0} 個"),
        ["showMore"] = L.T("Afficher 25 de plus", "Show 25 more", "Mostrar 25 más", "さらに25件表示"),
        ["noMatches"] = L.T("Aucune partie comptée pour l'instant.", "No match counted yet.", "Ninguna partida contada por ahora.", "まだ集計した試合はありません。"),
        ["overlay"] = L.T("Overlay", "Overlay", "Overlay", "オーバーレイ"),
        ["settings"] = L.T("Réglages", "Settings", "Ajustes", "設定"),
        ["help"] = L.T("Aide", "Help", "Ayuda", "ヘルプ"),
        ["total"] = L.T("Coffres au total", "Chests in total", "Cofres en total", "宝箱の合計"),
        ["totalSub"] = L.T("ouverts ou détruits par toi", "opened or destroyed by you", "abiertos o destruidos por ti", "あなたが開けた・壊した数"),
        ["byHand"] = L.T("dont {0} ajoutés à la main", "{0} of them added by hand", "de ellos, {0} añadidos a mano", "うち {0} 個は手動で追加"),
        ["session"] = L.T("Session", "Session", "Sesión", "セッション"),
        ["last"] = L.T("Dernière partie", "Last match", "Última partida", "前回の試合"),
        ["squad"] = L.T("Total d'équipe", "Squad total", "Total del equipo", "チーム合計"),
        ["squadSub"] = L.T("toi + {0} par tes coéquipiers", "you + {0} by your teammates", "tú + {0} de tus compañeros", "あなた + チームメイト {0} 個"),
        ["inaccurate"] = L.T("imprécis", "inaccurate", "impreciso", "不正確"),
        ["inaccurateWhy"] = L.T("Compté dans TES replays : un coffre ouvert par un coéquipier à plus de 150 m de toi n'y est pas, et rien n'est enregistré après ton départ de la partie. Le vrai total de l'équipe est plus haut.",
            "Counted in YOUR replays: a chest a teammate opens more than 150 m away from you is not in them, and nothing is recorded once you leave the match. The real squad total is higher.",
            "Contado en TUS repeticiones: un cofre que un compañero abre a más de 150 m de ti no está en ellas, y no se graba nada después de que salgas de la partida. El total real del equipo es mayor.", "あなたのリプレイから数えています。あなたから150m以上離れた場所でチームメイトが開けた宝箱は記録されず、あなたが試合を抜けた後も何も記録されません。実際のチーム合計はこれより多くなります。"),
        ["treasures"] = L.T("Trésors", "Treasures", "Tesoros", "お宝"),
        ["matches"] = L.T("parties", "matches", "partidas", "試合"),
        ["perMatch"] = L.T("{0} par partie", "{0} per match", "{0} por partida", "1試合あたり {0} 個"),
        ["openReport"] = L.T("Ouvrir le rapport", "Open the report", "Abrir el informe", "レポートを開く"),
        ["showOverlay"] = L.T("Afficher l'overlay", "Show the overlay", "Mostrar el overlay", "オーバーレイを表示"),
        ["hideOverlay"] = L.T("Masquer l'overlay", "Hide the overlay", "Ocultar el overlay", "オーバーレイを隠す"),
        ["lock"] = L.T("Verrouiller l'overlay", "Lock the overlay", "Bloquear el overlay", "オーバーレイを固定"),
        ["unlock"] = L.T("Déverrouiller pour le déplacer", "Unlock to move it", "Desbloquear para moverlo", "固定を解除して移動"),
        ["activity"] = L.T("Activité", "Activity", "Actividad", "アクティビティ"),
        ["noActivity"] = L.T("Rien pour l'instant.", "Nothing yet.", "Nada por ahora.", "まだ何もありません。"),
        ["analyzing"] = L.T("Analyse de tes replays…", "Analyzing your replays…", "Analizando tus repeticiones…", "リプレイを解析中…"),
        ["whatsNew"] = L.T("Nouveautés de la {0}", "What's new in {0}", "Novedades de la {0}", "{0} の新機能"),
        ["newVersion"] = L.T("Nouvelle version {0} disponible", "New version {0} available", "Nueva versión {0} disponible", "新しいバージョン {0} があります"),
        ["install"] = L.T("Installer", "Install", "Instalar", "インストール"),
        ["checkUpdate"] = L.T("Rechercher une mise à jour", "Check for updates", "Buscar actualizaciones", "アップデートを確認"),
        ["welcome"] = L.T("Bienvenue !", "Welcome!", "¡Bienvenido!", "ようこそ！"),
        ["welcomeText"] = L.T("Active d'abord les rediffusions dans Fortnite : Paramètres → Jeu → Rediffusions → Enregistrer les rediffusions. Ensuite, laisse le compteur ouvert : chaque partie est comptée quelques secondes après sa fin. Des coffres ouverts avant ? Le crayon de « Coffres au total » permet de les ajouter.",
            "First turn on replays in Fortnite: Settings → Game → Replays → Record Replays. Then keep the counter open: each match is counted a few seconds after it ends. Chests opened before? The pencil of \"Chests in total\" adds them.",
            "Primero activa las repeticiones en Fortnite: Ajustes → Juego → Repeticiones → Grabar repeticiones. Luego deja el contador abierto: cada partida se cuenta unos segundos después de terminar. ¿Cofres abiertos antes? El lápiz de «Cofres en total» permite añadirlos.", "まずFortniteでリプレイを有効にしてください: 設定 → ゲーム → リプレイ → リプレイを記録。あとはカウンターを開いたままにしておけば、各試合が終了の数秒後に集計されます。以前に開けた宝箱は「宝箱の合計」の鉛筆ボタンから追加できます。"),
        ["ok"] = L.T("OK", "OK", "OK", "OK"),
        ["moreInfo"] = L.T("En savoir plus", "More info", "Más información", "詳しく見る"),
        ["wMin"] = L.T("Réduire", "Minimize", "Minimizar", "最小化"),
        ["wMax"] = L.T("Agrandir", "Maximize", "Maximizar", "最大化"),
        ["wRestore"] = L.T("Niveau inférieur", "Restore down", "Restaurar", "元のサイズに戻す"),
        ["wClose"] = L.T("Fermer", "Close", "Cerrar", "閉じる"),
        ["keepOpen"] = L.T("Garder le compteur ouvert", "Keep the counter open", "Mantener el contador abierto", "カウンターを開いたままにする"),
        ["autoCloseText"] = L.T("Fortnite est fermé : le compteur, ouvert avec Fortnite, va se fermer tout seul.", "Fortnite is closed: the counter, opened with Fortnite, is about to close by itself.", "Fortnite está cerrado: el contador, abierto con Fortnite, se va a cerrar solo.", "Fortniteが終了しました。Fortniteと一緒に起動したカウンターは、まもなく自動で閉じます。"),
        ["welcomeQuick"] = L.T("Tes premiers réglages (tu les retrouves à tout moment dans Réglages) :", "Your first settings (you find them at any time in Settings):", "Tus primeros ajustes (los encuentras en cualquier momento en Ajustes):", "最初の設定（あとから「設定」でいつでも変更できます）:"),
        ["welcomeDone"] = L.T("C'est parti !", "Let's go!", "¡Vamos!", "はじめる！"),
        ["inGame"] = L.T("Overlay en jeu", "In-game overlay", "Overlay en el juego", "ゲーム内オーバーレイ"),
        ["inGameHelp"] = L.T("Petite fenêtre toujours au premier plan qui affiche tes coffres en jeu (Fortnite en « Plein écran fenêtré »). Ctrl+Maj+O : afficher / masquer, Ctrl+Maj+L : verrouiller.",
            "Small always-on-top window that shows your chests in game (Fortnite in \"Windowed Fullscreen\"). Ctrl+Shift+O: show / hide, Ctrl+Shift+L: lock.",
            "Pequeña ventana siempre visible que muestra tus cofres en el juego (Fortnite en «Pantalla completa en ventana»). Ctrl+Mayús+O: mostrar / ocultar, Ctrl+Mayús+L: bloquear.", "ゲーム中に宝箱の数を表示する、常に最前面の小さなウィンドウです（Fortniteは「ウィンドウ フルスクリーン」で使用）。Ctrl+Shift+O: 表示／非表示、Ctrl+Shift+L: 固定。"),
        ["style"] = L.T("Style", "Style", "Estilo", "スタイル"),
        ["card"] = L.T("Carte (coffre et compteurs)", "Card (chest and counters)", "Tarjeta (cofre y contadores)", "カード（宝箱と数字）"),
        ["hud"] = L.T("HUD (intégré au jeu)", "HUD (blends into the game)", "HUD (integrado en el juego)", "HUD（ゲームになじむ表示）"),
        ["classic"] = L.T("Classique (carte sombre)", "Classic (dark card)", "Clásico (tarjeta oscura)", "クラシック（暗いカード）"),
        ["size"] = L.T("Taille", "Size", "Tamaño", "サイズ"),
        ["opacity"] = L.T("Opacité", "Opacity", "Opacidad", "不透明度"),
        ["squadToggle"] = L.T("Afficher le total d'équipe", "Show the squad total", "Mostrar el total del equipo", "チーム合計を表示"),
        ["squadHelp"] = L.T("Tes coffres + ceux de tous tes coéquipiers (même aléatoires), sur l'overlay et l'accueil.",
            "Your chests + those of all your teammates (random ones too), on the overlay and the home tab.",
            "Tus cofres + los de todos tus compañeros (también los aleatorios), en el overlay y el inicio.", "あなたの宝箱 + すべてのチームメイト（野良も含む）の宝箱を、オーバーレイとホームに表示します。"),
        ["obs"] = L.T("Overlay pour OBS (stream)", "Overlay for OBS (stream)", "Overlay para OBS (directo)", "OBS用オーバーレイ（配信）"),
        ["obsSteps"] = L.T("Dans OBS : Sources → + → Navigateur, coche « Fichier local », choisis ce fichier. Largeur 400, hauteur 140 pour la carte (360 × 220 en HUD, 450 × 300 en classique). Pour ne l'avoir que sur le stream, désactive l'overlay en jeu : la page continue d'être mise à jour.",
            "In OBS: Sources → + → Browser, tick \"Local file\", pick this file. Width 400, height 140 for the card (360 × 220 for HUD, 450 × 300 for classic). To have it on the stream only, turn the in-game overlay off: the page keeps being updated.",
            "En OBS: Fuentes → + → Navegador, marca «Archivo local», elige este archivo. Ancho 400, alto 140 para la tarjeta (360 × 220 en HUD, 450 × 300 en clásico). Para tenerlo solo en el directo, desactiva el overlay en el juego: la página se sigue actualizando.", "OBSで: ソース → + → ブラウザ、「ローカルファイル」にチェックを入れてこのファイルを選択。カードは幅 400、高さ 140（HUD は 360 × 220、クラシックは 450 × 300）。配信にだけ表示したい場合はゲーム内オーバーレイをオフにしてください。ページは更新され続けます。"),
        ["copy"] = L.T("Copier le chemin", "Copy the path", "Copiar la ruta", "パスをコピー"),
        ["copied"] = L.T("Copié !", "Copied!", "¡Copiado!", "コピーしました！"),
        ["preview"] = L.T("Aperçu", "Preview", "Vista previa", "プレビュー"),
        ["language"] = L.T("Langue", "Language", "Idioma", "言語"),
        ["times"] = L.T("Heures affichées", "Times shown in", "Horas mostradas en", "時刻の表示"),
        ["timesHelp"] = L.T("Dans le rapport et ici : semaines, heures du trésor, parties.", "In the report and here: weeks, Treasure Hours, matches.", "En el informe y aquí: semanas, horas del tesoro, partidas.", "レポートとこの画面の、週・お宝タイム・試合の時刻。"),
        ["timesLocal"] = L.T("Heure locale ({0})", "Local time ({0})", "Hora local ({0})", "ローカル時刻（{0}）"),
        ["timesUtc"] = L.T("UTC (heure du jeu)", "UTC (game time)", "UTC (hora del juego)", "UTC（ゲーム内の時刻）"),
        ["clock"] = L.T("Horloge", "Clock", "Reloj", "時計"),
        ["clockAuto"] = L.T("Comme Windows ({0})", "Same as Windows ({0})", "Como Windows ({0})", "Windowsと同じ（{0}）"),
        ["clock12"] = L.T("12 heures (10:54 PM)", "12-hour (10:54 PM)", "12 horas (10:54 PM)", "12時間制（午後 10:54）"),
        ["clock24"] = L.T("24 heures (22:54)", "24-hour (22:54)", "24 horas (22:54)", "24時間制（22:54）"),
        ["h12"] = L.T("12 h", "12-hour", "12 h", "12時間制"),
        ["h24"] = L.T("24 h", "24-hour", "24 h", "24時間制"),
        ["tray"] = L.T("Réduire dans la zone de notification", "Minimize to the notification area", "Minimizar al área de notificación", "通知領域に最小化"),
        ["trayHelp"] = L.T("Oui : réduire la fenêtre la range à côté de l'horloge, en bas à droite de la barre des tâches (icône du coffre, parfois derrière la petite flèche ^). Non : elle reste dans la barre des tâches comme une fenêtre normale. Dans les deux cas, le compteur continue de compter.",
            "Yes: minimizing the window puts it next to the clock, at the bottom right of the taskbar (chest icon, sometimes behind the small ^ arrow). No: it stays in the taskbar like a normal window. Either way, the counter keeps counting.",
            "Sí: minimizar la ventana la coloca junto al reloj, abajo a la derecha de la barra de tareas (icono del cofre, a veces detrás de la pequeña flecha ^). No: se queda en la barra de tareas como una ventana normal. En ambos casos, el contador sigue contando.", "オン: ウィンドウを最小化すると、タスクバー右下の時計の横（宝箱アイコン。小さな ^ 矢印の中にある場合もあります）に格納されます。オフ: 通常のウィンドウと同じくタスクバーに残ります。どちらの場合もカウントは続きます。"),
        ["footerWindow"] = L.T("La croix de la fenêtre ferme le compteur (après confirmation).", "The close button of the window stops the counter (after asking).", "La cruz de la ventana cierra el contador (tras confirmarlo).", "ウィンドウの×ボタンでカウンターを終了します（確認あり）。"),
        ["withFortnite"] = L.T("Ouvrir avec Fortnite", "Open with Fortnite", "Abrir con Fortnite", "Fortniteと一緒に起動"),
        ["withFortniteHelp"] = L.T("Un petit processus invisible attend Fortnite et ouvre le compteur, qui se ferme après.", "A tiny invisible process waits for Fortnite and opens the counter, which closes afterwards.", "Un pequeño proceso invisible espera a Fortnite y abre el contador, que se cierra después.", "目に見えない小さなプロセスがFortniteの起動を待ってカウンターを開き、Fortnite終了後に閉じます。"),
        ["updates"] = L.T("Mises à jour", "Updates", "Actualizaciones", "アップデート"),
        ["upPrompt"] = L.T("Proposées", "Offered", "Propuestas", "確認してからインストール"),
        ["upAuto"] = L.T("Installées automatiquement", "Installed automatically", "Instaladas automáticamente", "自動でインストール"),
        ["upOff"] = L.T("Désactivées", "Off", "Desactivadas", "オフ"),
        ["profile"] = L.T("Compte (profil)", "Account (profile)", "Cuenta (perfil)", "アカウント（プロフィール）"),
        ["demos"] = L.T("Dossier des replays", "Replays folder", "Carpeta de repeticiones", "リプレイのフォルダー"),
        ["demosMissing"] = L.T("Introuvable : Fortnite le crée à la première partie enregistrée.", "Not found: Fortnite creates it with the first recorded match.", "No encontrada: Fortnite la crea con la primera partida grabada.", "見つかりません。最初の試合を記録したときにFortniteが作成します。"),
        ["save"] = L.T("Enregistrer", "Save", "Guardar", "保存"),
        ["editChests"] = L.T("Modifier mon nombre de coffres", "Edit my number of chests", "Modificar mi número de cofres", "宝箱の数を編集"),
        ["close"] = L.T("Fermer", "Close", "Cerrar", "閉じる"),
        ["manual"] = L.T("Coffres ajoutés à la main", "Chests added by hand", "Cofres añadidos a mano", "手動で追加した宝箱"),
        ["manualHelp"] = L.T("Les coffres ouverts avant d'utiliser le compteur. Chaque nombre s'ajoute à ce que tu as déjà ajouté (un nombre négatif en retire) ; la croix annule un ajout.", "The chests opened before using the counter. Each number is added to what you already added (a negative number removes some); the cross undoes an addition.", "Los cofres abiertos antes de usar el contador. Cada número se suma a lo que ya añadiste (un número negativo quita cofres); la cruz anula un añadido.", "カウンターを使う前に開けた宝箱です。入力した数はこれまでの追加分に足されます（マイナスの数で減らせます）。×で追加を取り消せます。"),
        ["manualTotal"] = L.T("Ajoutés à la main : {0}", "Added by hand: {0}", "Añadidos a mano: {0}", "手動で追加: {0}"),
        ["addBtn"] = L.T("Ajouter", "Add", "Añadir", "追加"),
        ["removeEntry"] = L.T("Annuler cet ajout", "Undo this addition", "Anular este añadido", "この追加を取り消す"),
        ["thisWeek"] = L.T("Ouverts cette semaine", "Opened this week", "Abiertos esta semana", "今週開けた"),
        ["thisWeekHelp"] = L.T("comptent aussi pour les trésors hebdo de la semaine {0}", "also count for the weekly treasures of week {0}", "cuentan también para los tesoros semanales de la semana {0}", "第{0}週の週替わりのお宝にも数えます"),
        ["estimate"] = L.T("Ou estimer à partir de tes parties", "Or estimate from your matches", "O estimar a partir de tus partidas", "または試合数から見積もる"),
        ["estimateHelp"] = L.T("Nombre de parties Battle Royale de la saison, dans Fortnite : Carrière → Statistiques.", "Number of Battle Royale matches this season, in Fortnite: Career → Stats.", "Número de partidas de Battle Royale de la temporada, en Fortnite: Carrera → Estadísticas.", "今シーズンのバトルロイヤルの試合数（Fortnite: キャリア → 統計）。"),
        ["career"] = L.T("Parties jouées", "Matches played", "Partidas jugadas", "プレイした試合数"),
        ["compute"] = L.T("Calculer", "Compute", "Calcular", "計算"),
        ["add"] = L.T("Ajouter {0} coffres", "Add {0} chests", "Añadir {0} cofres", "{0} 個を追加"),
        ["estimateTooFew"] = L.T("Il faut au moins {0} parties comptées pour une moyenne fiable.", "At least {0} counted matches are needed for a reliable average.", "Hacen falta al menos {0} partidas contadas para una media fiable.", "信頼できる平均には、集計済みの試合が {0} 試合以上必要です。"),
        ["estimateNothing"] = L.T("Rien à ajouter : tes parties comptées couvrent déjà ce nombre.", "Nothing to add: your counted matches already cover that number.", "Nada que añadir: tus partidas contadas ya cubren ese número.", "追加するものはありません。集計済みの試合でこの数はすでに満たしています。"),
        ["dataFolder"] = L.T("Ouvrir le dossier des données", "Open the data folder", "Abrir la carpeta de datos", "データフォルダーを開く"),
        ["errorLog"] = L.T("Ouvrir le journal d'erreurs", "Open the error log", "Abrir el registro de errores", "エラーログを開く"),
        ["issue"] = L.T("Signaler un problème (GitHub)", "Report a problem (GitHub)", "Informar de un problema (GitHub)", "問題を報告（GitHub）"),
        ["project"] = L.T("Page du projet (GitHub)", "Project page (GitHub)", "Página del proyecto (GitHub)", "プロジェクトページ（GitHub）"),
        ["helpText"] = L.T("Le compteur lit les replays que Fortnite enregistre et compte tes coffres quelques secondes après chaque partie (Battle Royale de la saison seulement). Laisse-le ouvert pendant que tu joues : tu peux réduire la fenêtre, il continue de compter.",
            "The counter reads the replays Fortnite saves and counts your chests a few seconds after each match (the season's Battle Royale only). Keep it open while you play: you can minimize the window, it keeps counting.",
            "El contador lee las repeticiones que guarda Fortnite y cuenta tus cofres unos segundos después de cada partida (solo el Battle Royale de la temporada). Déjalo abierto mientras juegas: puedes minimizar la ventana, sigue contando.", "カウンターはFortniteが保存するリプレイを読み取り、各試合の数秒後にあなたの宝箱を数えます（今シーズンのバトルロイヤルのみ）。プレイ中は開いたままにしてください。ウィンドウを最小化してもカウントは続きます。"),
        ["uninstall"] = L.T("Désinstaller ChestCounter", "Uninstall ChestCounter", "Desinstalar ChestCounter", "ChestCounterをアンインストール"),
        ["keepData"] = L.T("Garder mon historique et mes réglages", "Keep my history and settings", "Conservar mi historial y mis ajustes", "履歴と設定を残す"),
        ["deleteData"] = L.T("Tout supprimer", "Delete everything", "Borrarlo todo", "すべて削除"),
        ["uninstallConfirm"] = L.T("Désinstaller maintenant ? Le compteur se ferme et ChestCounter.exe est supprimé.", "Uninstall now? The counter closes and ChestCounter.exe is deleted.", "¿Desinstalar ahora? El contador se cierra y se borra ChestCounter.exe.", "今すぐアンインストールしますか？カウンターが閉じ、ChestCounter.exe が削除されます。"),
        ["quit"] = L.T("Quitter le compteur", "Quit the counter", "Salir del contador", "カウンターを終了"),
        ["quitConfirm"] = L.T("Arrêter le compteur ? Les parties jouées ensuite ne seront comptées qu'à sa prochaine ouverture.", "Stop the counter? Matches played afterwards are only counted when it is opened again.", "¿Detener el contador? Las partidas jugadas después solo se cuentan cuando se vuelva a abrir.", "カウンターを終了しますか？終了中にプレイした試合は、次に開いたときにだけ集計されます。"),
        ["closed"] = L.T("Le compteur est arrêté. Tu peux fermer cette fenêtre.", "The counter is stopped. You can close this window.", "El contador está detenido. Puedes cerrar esta ventana.", "カウンターは停止しました。このウィンドウを閉じてかまいません。"),
        ["offline"] = L.T("Le compteur ne répond plus (fermé ?). Relance ChestCounter.exe.", "The counter does not answer (closed?). Start ChestCounter.exe again.", "El contador no responde (¿cerrado?). Vuelve a abrir ChestCounter.exe.", "カウンターが応答しません（終了しましたか？）。ChestCounter.exe をもう一度起動してください。"),
        ["footer"] = L.T("Fermer cette fenêtre ne coupe pas le compteur.", "Closing this window does not stop the counter.", "Cerrar esta ventana no detiene el contador.", "このウィンドウを閉じてもカウンターは止まりません。"),
    };

    public static string Html(string token) => Template.Replace("__TOKEN__", token).Replace("__FONT__", ReportWriter.FontFaceCss).Replace("__PENCIL__", ReportWriter.PencilIcon);

    private const string Template = """
        <!doctype html><html><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
        <title>Chest Counter</title>
        <style>__FONT__
        :root{--bg:#0f1b24;--ink:#efe2c4;--muted:#b8b0a0;--title:#f0c057;--card:#f2e6c9;--cink:#2a1c0f;--cmuted:#6b5a44;--line:#d8c59c;--track:#e4d3ad;--gold:#c9a24f;--team:#1f7f7a;--warn:#a3361f}
        @media (prefers-color-scheme:light){:root{--bg:#efe4c9;--ink:#2a1c0f;--muted:#6b5a44;--title:#7a4a1e;--card:#fffaf0;--line:#e2d2ae;--track:#efe2c4}}
        *{box-sizing:border-box}
        body{margin:0;background:var(--bg);color:var(--ink);font:15px/1.5 "Segoe UI",system-ui,sans-serif}
        main{max-width:1080px;margin:0 auto;padding:24px 16px 40px;display:flex;flex-direction:column;gap:20px}
        .pirate{font-family:"Pirata One","Segoe UI",serif;font-weight:400}
        .num{font-family:Bahnschrift,"Segoe UI",sans-serif;font-stretch:75%;font-variant-numeric:tabular-nums}
        #app{display:flex;flex-direction:column;gap:20px}
        #hdr{display:flex;flex-direction:column;gap:16px}
        #view{display:flex;flex-direction:column;gap:20px}
        #view:empty{display:none}
        #rep{width:100%;min-height:400px;border:0;display:block;background:transparent;overflow:hidden}
        .who{display:flex;align-items:center;gap:10px;flex-wrap:wrap}
        .who select{min-height:32px;padding:2px 8px;font-size:14px;border-color:var(--gold);background:transparent;color:var(--ink)}
        .who select option{color:#2a1c0f;background:#fffaf0}
        header{display:flex;flex-wrap:wrap;align-items:center;justify-content:space-between;gap:12px;border-bottom:2px solid var(--gold);padding-bottom:14px}
        .brand{display:flex;align-items:center;gap:12px}
        h1{margin:0;font-size:38px;line-height:1;color:var(--title)}
        .who{color:var(--muted);font-size:14px}
        .pill{display:inline-flex;align-items:center;gap:8px;padding:6px 12px;border-radius:999px;background:var(--card);color:var(--cink);font-weight:600;font-size:14px}
        .pill i{width:10px;height:10px;border-radius:50%;background:#3a9a5b}
        .pill.live i{background:#ff3b30}.pill.busy i{background:#e0a526}.pill.warn i{background:#c8412f}
        nav{display:flex;gap:6px;flex-wrap:wrap}
        nav button{min-height:44px;padding:8px 18px;border-radius:8px;border:1px solid var(--gold);background:transparent;color:var(--ink);font:600 15px "Segoe UI",system-ui,sans-serif;cursor:pointer}
        nav button.on{background:var(--gold);color:var(--cink)}
        h2{margin:0 0 10px;font-size:24px;color:var(--title)}
        .tiles{display:grid;grid-template-columns:repeat(auto-fit,minmax(170px,1fr));gap:12px}
        .tile{background:var(--card);color:var(--cink);border:1px solid var(--line);border-radius:8px;padding:14px 16px}
        .tile .v{font-size:36px;font-weight:700;line-height:1.1}
        .tile .l{font-size:13px;color:var(--cmuted)}
        .tile.hero{position:relative;background:#7a4a1e;color:#fbecc4;border:2px solid #e7b440}
        .editbtn{position:absolute;top:10px;right:10px;width:36px;height:36px;padding:0;border-radius:8px;border:1px solid #e7b440;background:transparent;color:#ffd36a;cursor:pointer;display:grid;place-items:center}
        .editbtn:hover{background:rgba(231,180,64,.18)}.editbtn:focus-visible{outline:3px solid #ffd36a;outline-offset:2px}
        dialog{width:min(560px,calc(100% - 32px));padding:20px 22px;border:2px solid var(--gold);border-radius:10px;background:var(--card);color:var(--cink)}
        dialog::backdrop{background:rgba(5,10,14,.6)}
        .dhead{display:flex;align-items:center;justify-content:space-between;gap:12px;margin-bottom:6px}
        .dhead h2{margin:0;color:#7a4a1e}
        .dclose{width:40px;height:40px;border-radius:8px;border:1px solid var(--line);background:transparent;color:var(--cink);font-size:22px;line-height:1;cursor:pointer}
        .tile.hero .v{font-size:54px;color:#ffd36a}.tile.hero .l{color:#fbecc4}
        .card{background:var(--card);color:var(--cink);border:1px solid var(--line);border-radius:8px;padding:16px}
        .row{display:flex;align-items:center;justify-content:space-between;gap:16px;padding:12px 0;border-bottom:1px solid var(--line)}
        .row:last-child{border-bottom:none}
        .row .t{font-weight:600}.row .h{font-size:13px;color:var(--cmuted);margin-top:2px}
        .actions{display:flex;flex-wrap:wrap;gap:8px}
        button.b{min-height:40px;padding:8px 16px;border-radius:8px;border:1px solid var(--gold);background:var(--card);color:var(--cink);font:600 14px "Segoe UI",system-ui,sans-serif;cursor:pointer}
        button.b:hover{background:var(--track)}
        button.b.main{background:#7a4a1e;color:#fbecc4;border-color:#e7b440}
        button.b.danger{border-color:var(--warn);color:var(--warn)}
        select,input[type=text],input[type=number]{min-height:40px;padding:6px 10px;border-radius:6px;border:1px solid var(--line);background:#fffaf0;color:var(--cink);font:15px "Segoe UI",system-ui,sans-serif}
        input[type=text]{width:min(520px,100%)}
        .switch{position:relative;display:inline-block;width:52px;height:30px;flex:none;vertical-align:middle}
        .switch input{opacity:0;width:100%;height:100%;margin:0;cursor:pointer;position:absolute;z-index:1}
        .switch span{position:absolute;inset:0;border-radius:15px;background:#c9bc9c;transition:background .15s}
        .switch span:after{content:"";position:absolute;top:3px;left:3px;width:24px;height:24px;border-radius:50%;background:#fff;transition:transform .15s}
        .switch input:checked+span{background:var(--team)}.switch input:checked+span:after{transform:translateX(22px)}
        .switch input:focus-visible+span{outline:3px solid var(--gold)}
        .badge{display:inline-block;margin-left:6px;padding:1px 8px;border-radius:999px;background:#f6d8c9;color:var(--warn);font-size:12px;font-weight:700;vertical-align:1px;cursor:help}
        .log{font:13px/1.55 Consolas,"Cascadia Mono",monospace;max-height:260px;overflow:auto;white-space:pre-wrap}
        .log .err{color:#b3261e}.log .warn{color:#9a5b00}.log .ok{color:#1d7a3c}.log .info{color:#1f6f8b}.log .tre{color:#6c3fb5}.log .mut{color:var(--cmuted)}
        .bar{height:8px;background:var(--line);border-radius:4px;overflow:hidden;margin-top:8px}.bar i{display:block;height:100%;background:#b9821c}
        .path{font:13px Consolas,monospace;word-break:break-all;background:var(--track);padding:6px 8px;border-radius:6px;display:block;margin:6px 0}
        .note{font-size:13px;color:var(--muted)}
        .hidden{display:none!important}
        footer{display:flex;justify-content:space-between;align-items:center;gap:12px;flex-wrap:wrap;border-top:1px dashed var(--gold);padding-top:12px;color:var(--muted);font-size:13px}
        .estimate{margin-top:8px;font-weight:600}
        .mtotal{font-weight:600;margin-bottom:6px}
        .mweek{display:flex;align-items:center;gap:8px;margin-top:8px;cursor:pointer}
        .mweek b{white-space:nowrap}
        .mweek span{color:var(--cmuted);font-size:13px}
        .mhist{list-style:none;margin:10px 0 0;padding:0;max-height:190px;overflow:auto}
        .mhist li{display:flex;align-items:center;gap:12px;padding:5px 2px;border-top:1px solid var(--line)}
        .mhist b{min-width:70px;text-align:right}
        .mhist span{flex:1;color:var(--cmuted);font-size:13px}
        .mhist .mx{border:0;background:none;color:var(--cmuted);font-size:18px;line-height:1;cursor:pointer;padding:2px 7px;border-radius:4px}
        .mhist .mx:hover{color:var(--warn);background:rgba(163,54,31,.1)}
        .hist{overflow-x:auto}
        .hist table{width:100%;border-collapse:collapse;font-size:14px}
        .hist th{font-size:12px;color:var(--cmuted);text-align:left;font-weight:600;padding:6px 8px;border-bottom:2px solid var(--line);white-space:nowrap}
        .hist td{padding:6px 8px;border-bottom:1px solid var(--line);vertical-align:middle}
        .hist tr:last-child td{border-bottom:0}
        .hist .r{text-align:right}.nw{white-space:nowrap}.win{color:#b9821c;font-weight:700}
        .hman{font-size:12px;color:var(--cmuted);white-space:nowrap}
        .up{color:#2e8b57;font-size:12px}.down{color:var(--warn);font-size:12px}
        .ib{width:34px;height:34px;padding:0;border-radius:6px;border:1px solid var(--line);background:transparent;color:var(--cink);cursor:pointer;display:inline-grid;place-items:center}
        .ib:hover{background:var(--track)}.ib:focus-visible{outline:3px solid var(--gold);outline-offset:1px}
        .ib svg{width:16px;height:16px}
        .mfacts{margin:10px 0;padding-left:20px}.mfacts li{margin:2px 0}
        .dzone{margin-top:18px;border-top:1px solid var(--line);padding-top:14px}
        .notice{position:relative;display:flex;gap:12px;align-items:flex-start;border-left:6px solid var(--gold)}
        .notice.warning{border-left-color:#c8412f;background:#fbe9d0}
        .notice .ni{flex:none;width:24px;height:24px;border-radius:50%;display:grid;place-items:center;font:700 14px "Segoe UI",system-ui,sans-serif;background:var(--gold);color:#fff;margin-top:1px}
        .notice.warning .ni{background:#c8412f}
        .notice .nb{flex:1;min-width:0}.notice .nt{font-weight:700;margin-bottom:2px}.notice .nx{white-space:pre-line}
        .notice .actions{margin-top:10px}
        .notice .nclose{flex:none;width:32px;height:32px;margin:-6px -8px 0 0;border:0;border-radius:6px;background:transparent;color:var(--cmuted);font-size:20px;line-height:1;cursor:pointer}
        .notice .nclose:hover{background:rgba(0,0,0,.06);color:var(--cink)}
        @media (max-width:640px){.row{flex-direction:column;align-items:flex-start}}
        /* The counter's own window: its title bar is drawn here (drag to move, double click to maximize). */
        .tbar{display:none}
        body.windowed{height:100vh;overflow:hidden}
        body.windowed .tbar{display:flex;justify-content:flex-end;position:fixed;top:0;left:0;right:0;height:34px;background:var(--bg);z-index:20;app-region:drag;user-select:none}
        body.windowed #scroll{position:absolute;top:34px;left:0;right:0;bottom:0;overflow:auto}
        body.windowed header{app-region:drag}
        body.windowed header select,body.windowed header button{app-region:no-drag}
        .wctl{display:flex;app-region:no-drag}
        .wctl button{width:46px;height:34px;padding:0;border:0;border-radius:0;background:transparent;color:var(--muted);display:grid;place-items:center;cursor:pointer;transition:background .12s,color .12s}
        .wctl button:hover{background:rgba(201,162,79,.18);color:var(--title)}
        .wctl button.x:hover{background:#b3261e;color:#fff}
        .wctl button:focus-visible{outline:2px solid var(--gold);outline-offset:-2px}
        .wctl svg{display:block}
        /* Scrollbars in the colors of the tool (no white bar on the side). */
        #scroll::-webkit-scrollbar,html::-webkit-scrollbar{width:12px}
        #scroll::-webkit-scrollbar-track,html::-webkit-scrollbar-track{background:var(--bg)}
        #scroll::-webkit-scrollbar-thumb,html::-webkit-scrollbar-thumb{background:rgba(201,162,79,.32);border-radius:6px;border:3px solid var(--bg)}
        #scroll::-webkit-scrollbar-thumb:hover,html::-webkit-scrollbar-thumb:hover{background:rgba(201,162,79,.6)}
        .log::-webkit-scrollbar{width:10px}
        .log::-webkit-scrollbar-track{background:transparent}
        .log::-webkit-scrollbar-thumb{background:var(--line);border-radius:5px;border:2px solid var(--card)}
        </style></head><body><div class="tbar"><div class="wctl">
          <button type="button" id="wmin"><svg width="10" height="10" viewBox="0 0 10 10" aria-hidden="true"><path d="M0 5.5h10" stroke="currentColor" stroke-width="1.1"/></svg></button>
          <button type="button" id="wmax"><svg width="10" height="10" viewBox="0 0 10 10" aria-hidden="true"><rect id="wmaxicon" x=".55" y=".55" width="8.9" height="8.9" fill="none" stroke="currentColor" stroke-width="1.1"/><path id="wresicon" d="M2.5 2.5V.55h6.95v6.95H7.5M.55 2.5h6.95v6.95H.55z" fill="none" stroke="currentColor" stroke-width="1.1" style="display:none"/></svg></button>
          <button type="button" id="wclose" class="x"><svg width="10" height="10" viewBox="0 0 10 10" aria-hidden="true"><path d="M.5.5l9 9M9.5.5l-9 9" stroke="currentColor" stroke-width="1.2"/></svg></button>
        </div></div><div id="scroll"><main><div id="app"><p class="note">…</p></div><section id="activityPane" class="hidden"><h2 class="pirate"></h2><div class="card log"></div></section><section id="reportPane" class="hidden"><iframe id="rep" title="Report" scrolling="no"></iframe></section><div id="foot"></div></main></div>
        <dialog id="dlg" aria-labelledby="dlgT"><div class="dhead"><h2 class="pirate" id="dlgT"></h2><button type="button" class="dclose" id="dlgX">×</button></div><div id="dlgB"></div></dialog>
        <script>
        const TOKEN='__TOKEN__';let S=null,tab=(()=>{const h=location.hash.slice(1);if(['home','history','report','overlay','settings','help'].includes(h))return h;try{return localStorage.getItem('cc-gui-tab')||'home'}catch(e){return 'home'}})(),estimate=null,stopped=false,copied=false;
        const $=s=>document.querySelector(s);
        // In the counter's own window (?w=1): the title bar of the page, its buttons sent to the window.
        const host=window.chrome&&window.chrome.webview;let maximized=false;
        if(host&&new URLSearchParams(location.search).get('w')==='1')document.body.classList.add('windowed');
        const scroller=()=>document.body.classList.contains('windowed')?document.getElementById('scroll'):document.scrollingElement;
        function winBtn(a){if(host)host.postMessage({win:a})}
        function winTitles(){if(!S)return;const T=S.txt;$('#wmin').title=T.wMin;$('#wmin').setAttribute('aria-label',T.wMin);const m=maximized?T.wRestore:T.wMax;$('#wmax').title=m;$('#wmax').setAttribute('aria-label',m);$('#wclose').title=T.wClose;$('#wclose').setAttribute('aria-label',T.wClose)}
        if(host)host.addEventListener('message',e=>{const d=e.data;if(d&&typeof d.maximized==='boolean'){maximized=d.maximized;$('#wmaxicon').style.display=maximized?'none':'';$('#wresicon').style.display=maximized?'':'none';winTitles()}});
        const esc=s=>String(s??'').replace(/[&<>"']/g,c=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[c]));
        const fmt=(s,...a)=>a.reduce((r,v,i)=>r.replace('{'+i+'}',v),s);
        async function api(action,value){const r=await fetch('/api/action',{method:'POST',headers:{'X-Token':TOKEN,'Content-Type':'application/json'},body:JSON.stringify({action,value})});const j=await r.json();await refresh(true);return j.result}
        async function refresh(force){if(stopped)return;try{const r=await fetch('/api/state',{headers:{'X-Token':TOKEN}});S=await r.json();render(force)}catch(e){if(S){$('#app').innerHTML='<div class="card">'+esc(S.txt.offline)+'</div>';appHtml=null;$('#activityPane').classList.add('hidden')}}}
        function busy(){const a=document.activeElement;return a&&a.closest&&a.closest('#view')&&/INPUT|SELECT|TEXTAREA/.test(a.tagName)}
        function busyHeader(){const a=document.activeElement;return a&&a.closest&&a.closest('#hdr')&&a.tagName==='SELECT'}
        function sw(id,on,act){return `<label class="switch"><input type="checkbox" id="${id}" ${on?'checked':''} onchange="api('${act}',this.checked)"><span></span></label>`}
        function row(title,help,control){return `<div class="row"><div><div class="t">${title}</div>${help?`<div class="h">${help}</div>`:''}</div><div>${control}</div></div>`}
        function sel(act,value,opts){return `<select onchange="api('${act}',this.value)">${opts.map(o=>`<option value="${esc(o[0])}" ${String(o[0])===String(value)?'selected':''}>${esc(o[1])}</option>`).join('')}</select>`}
        function setTab(t){tab=t;try{localStorage.setItem('cc-gui-tab',t)}catch(e){}render(true)}
        function render(force){
          const T=S.txt;document.documentElement.lang=S.lang;
          const head=`<header><div class="brand"><svg width="44" height="44" viewBox="0 0 56 56" aria-hidden="true"><rect x="6" y="20" width="44" height="28" rx="4" fill="#7a4a1e" stroke="#e7b440" stroke-width="3"/><path d="M6 26 Q28 4 50 26" fill="#965d27" stroke="#e7b440" stroke-width="3"/><rect x="24" y="24" width="8" height="10" rx="2" fill="#e7b440"/></svg><div><h1 class="pirate">${esc(S.appName)}</h1><div class="who">${S.profiles.length>1?`<select aria-label="${esc(T.profile)}" title="${esc(T.profile)}" onchange="api('profile',this.value)">${S.profiles.map(p=>`<option value="${esc(p.key)}" ${p.key===S.profileKey?'selected':''}>${esc(p.name)} (${esc(p.matches)})</option>`).join('')}</select>`:`<span>${esc(S.player||'')}</span>`}<span>v${esc(S.version)}</span></div></div></div><span class="pill ${S.status.kind}"><i></i>${esc(S.status.text)}</span></header>
          <nav>${['home','history','report','overlay','settings','help'].map(t=>`<button class="${t===tab?'on':''}" onclick="setTab('${t}')">${esc(T[t])}</button>`).join('')}</nav>`;
          if(!force&&busyHeader())return;
          if(!force&&busy()){$('#hdr').innerHTML=head;appHtml=null;return}
          // A click in progress (button pressed, not released yet): rebuilding now would replace its button and the click
          // would be lost. The next refresh, 2 s later, catches up.
          if(!force&&pressedAt&&Date.now()-pressedAt<3000)return;
          let v='';
          if(tab==='home')v=home(T);else if(tab==='history')v=history(T);else if(tab==='overlay')v=overlay(T);else if(tab==='settings')v=settings(T);else if(tab==='help')v=help(T);
          // Rebuilt only when something changed: the buttons stay the same elements between two refreshes.
          const app=`<div id="hdr">${head}</div>${notices(T)}<div id="view">${v}</div>`;
          if(force||app!==appHtml){$('#app').innerHTML=app;appHtml=app}
          // In the counter's own window the close button asks and stops it: no "quit" button needed.
          const foot=S.settings.windowed?`<footer><span>${esc(T.footerWindow)}</span></footer>`:`<footer><span>${esc(T.footer)}</span><button class="b danger" onclick="quit()">${esc(T.quit)}</button></footer>`;
          if(force||foot!==footHtml){$('#foot').innerHTML=foot;footHtml=foot}
          showActivity(T);showReport();winTitles();
        }
        // pressedAt: when the mouse button went down (0 once released). Forgotten after 3 s in case the release was
        // missed (outside the window), so the page never stops refreshing.
        let appHtml=null,footHtml=null,pressedAt=0;
        document.addEventListener('pointerdown',()=>{pressedAt=Date.now()},true);
        ['pointerup','pointercancel'].forEach(t=>document.addEventListener(t,()=>{pressedAt=0},true));
        let activityHtml=null;
        function showActivity(T){
          const pane=$('#activityPane');
          pane.classList.toggle('hidden',tab!=='home');
          if(tab!=='home')return;
          pane.querySelector('h2').textContent=T.activity;
          // Keep the scrolling element mounted while new log entries arrive.
          const log=pane.querySelector('.log');
          const html=S.activity.length?S.activity.map(l=>l.map(s=>`<span class="${s.c}">${esc(s.t)}</span>`).join('')).join('\n'):esc(T.noActivity);
          if(activityHtml===html)return;
          const top=log.scrollTop;
          log.innerHTML=html;
          log.scrollTop=top;
          activityHtml=html;
        }
        // The report, in the window: loaded once, then again only when the counter rewrote it (new match, setting...).
        let repStamp=null,repObs=null;
        // Height of the report's content (not of its frame: it shrinks again when a list is folded).
        function fitReport(){const f=$('#rep');try{const m=f.contentDocument.querySelector('main');f.style.height=Math.ceil(m.getBoundingClientRect().height)+'px'}catch(e){}}
        function showReport(){
          const pane=$('#reportPane'),f=$('#rep');pane.classList.toggle('hidden',tab!=='report');
          if(tab!=='report'||S.reportStamp===repStamp)return;
          const y=scroller().scrollTop;repStamp=S.reportStamp;
          f.onload=()=>{fitReport();scroller().scrollTop=y;try{if(repObs)repObs.disconnect();repObs=new ResizeObserver(fitReport);repObs.observe(f.contentDocument.querySelector('main'))}catch(e){}};
          f.src='/report?t='+TOKEN+'&v='+encodeURIComponent(repStamp);
        }
        // Messages of content.json (a known problem, a fix to install...): above every tab.
        function notices(T){return (S.notices||[]).map(n=>`<div class="card notice ${n.level==='warning'?'warning':''}" role="${n.level==='warning'?'alert':'status'}"><span class="ni" aria-hidden="true">${n.level==='warning'?'!':'i'}</span><div class="nb">${n.title?`<div class="nt">${esc(n.title)}</div>`:''}<div class="nx">${esc(n.text)}</div>${n.link?`<div class="actions"><button class="b ${n.level==='warning'?'main':''}" onclick="window.open('${esc(n.link)}','_blank')">${esc(T.moreInfo)}</button></div>`:''}</div>${n.level==='info'?`<button class="nclose" title="${esc(T.close)}" aria-label="${esc(T.close)}" onclick="api('dismissNotice','${esc(n.id)}')">×</button>`:''}</div>`).join('')}
        function home(T){
          let h='';
          if(S.autoClose)h+=`<div class="card notice warning"><b>${esc(S.status.text)}</b><br>${esc(T.autoCloseText)}<div class="actions" style="margin-top:10px"><button class="b main" onclick="api('keepOpen')">${esc(T.keepOpen)}</button></div></div>`;
          if(S.firstRun){const s=S.settings;h+=`<div class="card welcome"><h2 class="pirate" style="color:#7a4a1e">${esc(T.welcome)}</h2><p style="margin-top:0">${esc(T.welcomeText)}</p>
            <div class="t" style="font-weight:600;margin-top:14px">${esc(T.welcomeQuick)}</div>
            ${row(esc(T.language),'',sel('language',s.language,s.languages))}
            ${row(esc(T.inGame),esc(T.inGameHelp),sw('wov',S.overlay.show,'showOverlay'))}
            ${s.windowed?row(esc(T.tray),esc(T.trayHelp),sw('wtr',s.minimizeToTray,'minimizeToTray')):''}
            <div class="actions" style="margin-top:12px"><button class="b main" onclick="api('dismissWelcome')">${esc(T.welcomeDone)}</button></div></div>`}
          if(S.progress)h+=`<div class="card"><b>${esc(T.analyzing)} ${S.progress.done} / ${S.progress.total}</b><div class="bar"><i style="width:${Math.round(100*S.progress.done/Math.max(1,S.progress.total))}%"></i></div></div>`;
          if(S.whatsNew&&S.whatsNew.length)h+=`<div class="card"><h2 class="pirate" style="color:#7a4a1e">${esc(fmt(T.whatsNew,S.version))}</h2><ul>${S.whatsNew.map(n=>`<li>${esc(n)}</li>`).join('')}</ul><button class="b main" onclick="api('dismissWhatsNew')">${esc(T.ok)}</button></div>`;
          if(S.update)h+=`<div class="card"><h2 class="pirate">${esc(fmt(T.newVersion,S.update.version))}</h2><ul>${S.update.notes.map(n=>`<li>${esc(n)}</li>`).join('')}</ul><button class="b main" onclick="api('installUpdate')">${esc(T.install)}</button></div>`;
          h+=`<section class="tiles"><div class="tile hero"><button type="button" class="editbtn" onclick="openManual()" title="${esc(T.editChests)}" aria-label="${esc(T.editChests)}">__PENCIL__</button><div class="l">${esc(T.total)}</div><div class="v num">${esc(S.total)}</div><div class="l">${esc(T.totalSub)}${S.manual?'<br>'+esc(fmt(T.byHand,S.manualText.replace('+',''))):''}</div></div>
            <div class="tile"><div class="v num">${esc(S.session)}</div><div class="l">${esc(T.session)} · ${esc(S.sessionMatches)} ${esc(T.matches)}</div></div>
            <div class="tile"><div class="v num">${esc(S.last?S.last.chests:'—')}</div><div class="l">${esc(T.last)}${S.last?'<br>'+esc(S.last.when)+' · '+esc(S.last.mode)+' · '+esc(S.last.duration):''}</div></div>
            <div class="tile"><div class="v num">${esc(S.avgTime)}</div><div class="l">${esc(T.avgTime)}<br>${esc(fmt(T.perMinute,S.perMinute))}</div></div>
            ${S.squad?`<div class="tile"><div class="v num">${esc(S.squad.total)}</div><div class="l">${esc(T.squad)}<span class="badge" title="${esc(T.inaccurateWhy)}">${esc(T.inaccurate)}</span><br>${esc(fmt(T.squadSub,S.squad.team))}</div></div>`:''}
            <div class="tile"><div class="v num">★ ${esc(S.treasures)}</div><div class="l">${esc(T.treasures)} · ${esc(S.matches)} ${esc(T.matches)} · ${esc(fmt(T.perMatch,S.average))}</div></div></section>`;
          h+=`<div class="actions"><button class="b main" onclick="setTab('report')">${esc(T.openReport)}</button>`;
          if(S.overlay.running)h+=`<button class="b" onclick="api('toggleOverlayVisible')">${esc(S.overlay.visible?T.hideOverlay:T.showOverlay)}</button><button class="b" onclick="api('toggleOverlayLock')">${esc(S.overlay.locked?T.unlock:T.lock)}</button>`;
          if(!S.update&&S.updatesOn)h+=`<button class="b" onclick="api('checkUpdate')">${esc(T.checkUpdate)}</button>`;
          h+='</div>';
          return h;
        }
        function overlay(T){
          const o=S.overlay;
          let h=`<div class="card">${row(esc(T.inGame),esc(T.inGameHelp),sw('ov',o.show,'showOverlay'))}
            ${row(esc(T.style),'',sel('overlayStyle',o.style,[['card',T.card],['hud',T.hud],['classic',T.classic]]))}
            ${o.show?row(esc(T.size),'',sel('overlaySize',o.size,o.sizes.map(x=>[x,x+' %'])))+row(esc(T.opacity),'',sel('overlayOpacity',o.opacity,o.opacities.map(x=>[x,x+' %']))):''}
            ${row(esc(T.squadToggle)+`<span class="badge" title="${esc(T.inaccurateWhy)}">${esc(T.inaccurate)}</span>`,esc(T.squadHelp)+'<br>'+esc(T.inaccurateWhy),sw('sq',o.squad,'showSquadTotal'))}</div>
            <section><h2 class="pirate">${esc(T.obs)}</h2><div class="card"><span class="path">${esc(S.paths.overlay)}</span><p class="note" style="color:var(--cmuted)">${esc(T.obsSteps)}</p>
            <div class="actions"><button class="b main" onclick="copyObs()">${esc(copied?T.copied:T.copy)}</button><button class="b" onclick="window.open('/overlay?t='+TOKEN,'_blank')">${esc(T.preview)}</button></div></div></section>`;
          return h;
        }
        function settings(T){
          const s=S.settings;
          let h=`<div class="card">${row(esc(T.language),'',sel('language',s.language,s.languages))}
            ${row(esc(T.times),esc(T.timesHelp),sel('timeZone',s.timeZone,[['local',fmt(T.timesLocal,s.localZone)],['utc',T.timesUtc]]))}
            ${row(esc(T.clock),'',sel('clockFormat',s.clockFormat,[['auto',fmt(T.clockAuto,s.windowsClock==='24'?T.h24:T.h12)],['12',T.clock12],['24',T.clock24]]))}
            ${S.profiles.length>1?row(esc(T.profile),'',sel('profile',S.profileKey,S.profiles.map(p=>[p.key,p.name+' ('+p.matches+' · '+p.chests+')']))):''}
            ${s.windowed?row(esc(T.tray),esc(T.trayHelp),sw('tr',s.minimizeToTray,'minimizeToTray')):''}
            ${s.canStartWithFortnite?row(esc(T.withFortnite),esc(T.withFortniteHelp),sw('wf',s.startWithFortnite,'startWithFortnite')):''}
            ${row(esc(T.updates),'',sel('updateMode',s.updateMode,[['prompt',T.upPrompt],['auto',T.upAuto],['off',T.upOff]]))}
            <div class="row"><div style="flex:1"><div class="t">${esc(T.demos)}</div>${s.demosExists?'':`<div class="h">${esc(T.demosMissing)}</div>`}<div class="actions" style="margin-top:6px"><input type="text" id="demos" value="${esc(s.demos)}"><button class="b" onclick="api('demosFolder',$('#demos').value)">${esc(T.save)}</button></div></div></div></div>`;
          return h;
        }
        // Chests added by hand (and the estimate from the Career matches): p = 's' in the settings, 'd' in the edit box.
        // The box starts empty each time: the number typed is added to what was already added, and each addition can be
        // undone with its cross (issue #27).
        function manualForm(T,p){
          const hist=S.manualHistory||[];
          return `<p class="note" style="color:var(--cmuted);margin-top:0">${esc(T.manualHelp)}</p>
            <div class="mtotal">${esc(fmt(T.manualTotal,S.manualText))}</div>
            <div class="actions"><input type="number" id="${p}manual" step="1" placeholder="0" aria-label="${esc(T.manual)}" onkeydown="if(event.key==='Enter')addManual('${p}')"><button class="b main" onclick="addManual('${p}')">${esc(T.addBtn)}</button></div>
            ${S.manualWeek?`<label class="mweek"><input type="checkbox" id="${p}week"><b>${esc(T.thisWeek)}</b><span>${esc(fmt(T.thisWeekHelp,S.manualWeek))}</span></label>`:''}
            ${hist.length?`<ul class="mhist">${hist.map(e=>`<li><b class="num">${esc(e.chests)}</b><span>${esc([e.what,e.when].filter(Boolean).join(' · '))}</span><button type="button" class="mx" title="${esc(T.removeEntry)}" aria-label="${esc(T.removeEntry)}" onclick="removeManual('${p}','${esc(e.id)}')">×</button></li>`).join('')}</ul>`:''}
            <div class="t" style="margin-top:16px;font-weight:600">${esc(T.estimate)}</div><p class="note" style="color:var(--cmuted)">${esc(T.estimateHelp)}</p>
            <div class="actions"><input type="number" id="${p}career" min="0" placeholder="${esc(T.career)}" aria-label="${esc(T.career)}"><button class="b" onclick="doEstimate('${p}')">${esc(T.compute)}</button></div>
            <div class="estimate" id="${p}est">${estimate&&estimate.p===p?estimateHtml(T,p):''}</div>`;
        }
        function estimateHtml(T,p){if(estimate.error)return esc(estimate.error);return esc(estimate.text)+`<div class="actions" style="margin-top:8px"><button class="b main" onclick="addEstimate('${p}')">${esc(fmt(T.add,estimate.chestsText))}</button></div>`}
        async function doEstimate(p){const r=await api('estimate',parseInt($('#'+p+'career').value||'0',10));estimate=Object.assign({p},r);const e=$('#'+p+'est');if(e)e.innerHTML=estimateHtml(S.txt,p)}
        async function addManual(p){const i=$('#'+p+'manual'),w=$('#'+p+'week'),n=parseInt(i&&i.value||'0',10);if(!n){if(i)i.focus();return}await api('manualAdd',{chests:n,thisWeek:!!(w&&w.checked)});redrawManual(p)}
        async function addEstimate(p){if(!estimate||estimate.error)return;await api('manualEstimate',{chests:estimate.chests,career:estimate.career});redrawManual(p)}
        async function removeManual(p,id){await api('manualRemove',id);redrawManual(p)}
        // After a change the box stays open, with the new total and history, ready for the next number.
        function redrawManual(p){estimate=null;if(p!=='d'){render(true);return}$('#dlgB').innerHTML=manualForm(S.txt,'d');const i=$('#dmanual');if(i)i.focus()}
        // The edit box of "chests in total" (home tab, and the report's pencil through a message).
        function openManual(){const T=S.txt,d=$('#dlg');estimate=null;$('#dlgT').textContent=T.editChests;$('#dlgB').innerHTML=manualForm(T,'d');$('#dlgX').setAttribute('aria-label',T.close);if(!d.open)d.showModal();const i=$('#dmanual');if(i){i.focus();i.select()}}
        $('#dlgX').onclick=()=>$('#dlg').close();
        $('#wmin').onclick=()=>winBtn('min');$('#wmax').onclick=()=>winBtn('max');$('#wclose').onclick=()=>winBtn('close');
        // A click on the dimmed backdrop closes the box, only when it starts there too: selecting the number with the mouse
        // and releasing the button outside the box must not close it.
        let dlgDownOut=false;
        function dlgOutside(e){const r=$('#dlg').getBoundingClientRect();return e.target.id==='dlg'&&(e.clientX<r.left||e.clientX>r.right||e.clientY<r.top||e.clientY>r.bottom)}
        $('#dlg').addEventListener('pointerdown',e=>{dlgDownOut=dlgOutside(e)});
        $('#dlg').addEventListener('click',e=>{if(dlgDownOut&&dlgOutside(e))$('#dlg').close();dlgDownOut=false});
        window.addEventListener('message',e=>{if(e.origin===location.origin&&e.data&&e.data.cc==='editChests'&&S)openManual()});
        // History tab: the matches of the profile shown (25 at a time), the pencil opens the edit box of one match.
        let histShown=25,editId=null;
        function history(T){
          const H=S.history||[],D=S.deleted||[];
          let h=`<p class="note" style="margin:0">${esc(T.histIntro)}</p>
            <section class="tiles"><div class="tile"><div class="v num">${esc(S.matches)}</div><div class="l">${esc(T.matches)}</div></div>
            <div class="tile"><div class="v num">${esc(S.avgTime)}</div><div class="l">${esc(T.avgTime)}</div></div>
            <div class="tile"><div class="v num">${esc(S.perMinute)}</div><div class="l">${esc(T.perMinuteLabel)}</div></div>
            <div class="tile"><div class="v num">${esc(S.average)}</div><div class="l">${esc(T.perMatchLabel)}</div></div></section>`;
          if(!H.length)h+=`<div class="card">${esc(T.noMatches)}</div>`;
          else h+=`<div class="card hist"><table><thead><tr><th>${esc(T.colDate)}</th><th>${esc(T.colMode)}</th><th>${esc(T.colPlace)}</th><th class="r">${esc(T.colTime)}</th><th class="r">${esc(T.colChests)}</th><th class="r">${esc(T.colEff)}</th><th></th></tr></thead><tbody>${H.slice(0,histShown).map(m=>`<tr><td class="num nw">${esc(m.when)}</td><td>${esc(m.mode)}</td><td class="nw${m.win?' win':''}">${esc(m.place)}</td><td class="r num">${esc(m.duration)}</td><td class="r num nw"><b>${esc(m.chests)}</b>${m.manual?` <span class="hman" title="${esc(fmt(T.byHandMatch,m.manual))}">✎${esc(m.manual)}</span>`:''}</td><td class="r num nw" title="${esc(m.effTip)}">${esc(m.rate)}${m.cmp===1?' <span class="up">▲</span>':m.cmp===-1?' <span class="down">▼</span>':''}</td><td class="r"><button type="button" class="ib" title="${esc(T.editMatch)}" aria-label="${esc(T.editMatch)}" onclick="openMatch('${esc(m.id)}')">__PENCIL__</button></td></tr>`).join('')}</tbody></table>
            ${H.length>histShown?`<div class="actions" style="margin-top:10px"><button class="b" onclick="histShown+=25;render(true)">${esc(T.showMore)}</button></div>`:''}</div>`;
          if(D.length)h+=`<section><h2 class="pirate">${esc(T.deleted)}</h2><div class="card"><p class="note" style="color:var(--cmuted);margin-top:0">${esc(T.deletedHelp)}</p>${D.map(m=>`<div class="row"><div><div class="t">${esc(m.when)} · ${esc(m.mode)} · ${esc(fmt(T.chestsN,m.chests))}</div><div class="h">${esc(fmt(T.deletedOn,m.deletedWhen))}</div></div><button class="b" onclick="api('matchRestore','${esc(m.id)}')">${esc(T.restore)}</button></div>`).join('')}</div></section>`;
          return h;
        }
        function matchForm(T,m){return `<div class="mtotal">${esc(m.when)} · ${esc(m.mode)} · ${esc(m.place)} · ${esc(m.duration)}</div>${m.file?`<div class="note" style="color:var(--cmuted)">${esc(m.file)}</div>`:''}
          <ul class="mfacts"><li>${esc(fmt(T.counted,m.counted))}</li><li>${esc(fmt(T.byHandMatch,m.manual||'0'))}</li><li><b>${esc(fmt(T.matchTotal,m.chests))}</b></li><li>${esc(fmt(T.effLine,m.effTip))}</li></ul>
          <p class="note" style="color:var(--cmuted)">${esc(T.adjustHelp)}</p>
          <div class="actions"><input type="number" id="madj" step="1" placeholder="0" aria-label="${esc(T.colChests)}" onkeydown="if(event.key==='Enter')adjustMatch()"><button class="b main" onclick="adjustMatch()">${esc(T.addBtn)}</button>${m.manual?`<button class="b" onclick="resetMatch()">${esc(T.resetAdjust)}</button>`:''}</div>
          <div class="actions dzone"><button class="b danger" onclick="deleteMatch()">${esc(T.deleteMatch)}</button></div>`}
        function openMatch(id){const T=S.txt,d=$('#dlg'),m=(S.history||[]).find(x=>x.id===id);if(!m){if(d.open)d.close();return}editId=id;estimate=null;$('#dlgT').textContent=T.editMatch;$('#dlgB').innerHTML=matchForm(T,m);$('#dlgX').setAttribute('aria-label',T.close);if(!d.open)d.showModal();const i=$('#madj');if(i)i.focus()}
        async function adjustMatch(){const i=$('#madj'),n=parseInt(i&&i.value||'0',10);if(!n){if(i)i.focus();return}await api('matchAdjust',{id:editId,chests:n});openMatch(editId)}
        async function resetMatch(){await api('matchReset',editId);openMatch(editId)}
        async function deleteMatch(){if(!confirm(S.txt.deleteConfirm))return;await api('matchDelete',editId);editId=null;$('#dlg').close()}
        async function copyObs(){await api('copyObsPath');copied=true;render(true);setTimeout(()=>{copied=false;render(true)},2000)}
        function help(T){
          return `<div class="card"><p style="margin-top:0">${esc(T.helpText)}</p><div class="actions"><button class="b" onclick="api('openDataFolder')">${esc(T.dataFolder)}</button>${S.paths.errorLog?`<button class="b" onclick="api('openErrorLog')">${esc(T.errorLog)}</button>`:''}<button class="b" onclick="api('openIssues')">${esc(T.issue)}</button><button class="b" onclick="api('openRepo')">${esc(T.project)}</button></div></div>
          ${S.canUninstall?`<section><h2 class="pirate">${esc(T.uninstall)}</h2><div class="card"><span class="path">${esc(S.paths.data)}</span>
          <div class="actions"><button class="b danger" onclick="uninstall(false)">${esc(T.uninstall)} · ${esc(T.keepData)}</button><button class="b danger" onclick="uninstall(true)">${esc(T.uninstall)} · ${esc(T.deleteData)}</button></div></div></section>`:''}`;
        }
        function closedView(){stopped=true;$('#app').innerHTML='<div class="card">'+esc(S.txt.closed)+'</div>';$('#foot').innerHTML='';appHtml=footHtml=null;$('#activityPane').classList.add('hidden');$('#reportPane').classList.add('hidden')}
        async function uninstall(all){if(!confirm(S.txt.uninstallConfirm))return;await api('uninstall',all);closedView()}
        async function quit(){if(!confirm(S.txt.quitConfirm))return;try{await api('quit')}catch(e){}closedView()}
        refresh(true);setInterval(()=>refresh(false),2000);
        </script></body></html>
        """;
}
