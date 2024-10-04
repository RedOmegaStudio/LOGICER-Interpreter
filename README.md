#### mouth.new_words = "text";
- wypisze "text"
#### mind.sit();
- kończy program
#### mind.sleep(sekundy);
- poczeka określoną liczbę sekund
#### mouth.status += status.opened_level(close/open);
- zakazuje/zezwala na wypisywanie tekstu
#### mouth.status += status.hidden_words(show/hide);
- pokazuje ukryte wiadomości

### Kod:
`~~ Komentarz: Ukrywamy wiadomości, zamykamy konsolę
mouth.status += status.hidden_words(hide);
mouth.status += status.opened_level(close);
mouth.new_words = "To się nie wypisze";
~~ Komentarz: Konsola otwiera się, wiadomości widoczne
mind.sleep(2);
mouth.status += status.opened_level(open);
mouth.new_words = "To się wypisze";
~~ Program czeka przez określoną ilość sekund, a następnie się zatrzymuje
mind.sleep(2);
mind.sit();
`
