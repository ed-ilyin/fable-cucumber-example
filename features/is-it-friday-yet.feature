Feature: Is it Friday yet?
  Everybody wants to know when it's Friday

  Scenario Outline: Today is or is not Friday
    Given today is <day> <fay>
    When I ask whether it's Friday yet
    Then I ask whether it's Friday yet
    Then I should be told <answer>

  Examples:
    | day | fay | answer |
    | "Friday" | "abba" | "TGIF" |
    | "Sunday" | "babba" | "Nope" |
    | "anything else!" | "schwabra" | "Nope" |
