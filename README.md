**Note - The use of this plugin or familiarization with the source code to persons residing in: the Baltic States, North America, as well as in European countries whose policies are unfriendly to Russia, is prohibited, as well as persons identifying themselves as non-binary, transgender, is also prohibited.**

# Bulldog-Warnings
Это плагин, позволяющий логгировать потенциальные нарушения игроков для администраторов.</br>
>Команды:

| CMD  | Информация |
| ------------- | ------------- |
| .warnings (switch)  | Переключает статус варнингов для администратора.  |
| .switch (value/switch)  | Переключает значения отображения варнингов для администратора.  |
| .shint (switch)  | Переключает статус показа подсказок для администратора.  |
| .globalswitch (value/switch)  | Переключает значения отображения варнингов для **всех** администраторов.  |
| .debug (value)  | Запоминает состояние персонажа и сверяет __[ДЛЯ РАЗРАБОТЧИКОВ]__  |
| .wclear  | Очищает список жалоб.  |
| .sloot (value/switch)  | Переключает ограничение видимости предметов __[ЭКСПЕРИМЕНТАЛЬНО]__  |

---
>Статус обнаружения:
- Silent Aim - `Обнаружен`
- NoClip IteamStealer - `Обнаружен`
- Door Manipulator - `Обнаружен`
- Elevator Manipulator - `Обнаружен`
- Genocide - `вспомогательная функция`
- DoubleTap - `Обнаружен`
- NoRecoil - `Обнаружен`
---
> Погрешность

Система обнаружений в частности основана на сверении массива столкновений луча игрока RaycastAll с правильным результатом,
что может вызывать ложные срабатывания на честных игроков. Поэтому, рекомендую не включать отображение подсказок для администраторов в конфиге.
Также следует обращать внимания на количество жалоб, это играет наиболее важную роль, чем их больше, тем выше шанс, что игрок использует стороннее ПО.


