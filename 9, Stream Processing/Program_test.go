package main

import "testing"

func TestFirst(t *testing.T) {

	tables := []struct {
		testStream string
		correct    int
	}{
		{"{}", 1},
		{"{{{}}}", 6},
		{"{{},{}}", 5},
		{"{{{},{},{{}}}}", 16},
		{"{<a>,<a>,<a>,<a>}", 1},
		{"{{<ab>},{<ab>},{<ab>},{<ab>}}", 9},
		{"{{<!!>},{<!!>},{<!!>},{<!!>}}", 9},
		{"{{<a!>},{<a!>},{<a!>},{<ab>}}", 3},
	}

	for _, table := range tables {
		value := first(table.testStream)
		if value != table.correct {
			t.Errorf("Testing of %s did not pass, got: %d, want: %d.", table.testStream, value, table.correct)
		}
	}
}
func TestSecond(t *testing.T) {

	tables := []struct {
		testStream string
		correct    int
	}{
		{"<>", 0},
		{"<random characters>", 17},
		{"<<<<>", 3},
		{"<{!>}>", 2},
		{"<!!>", 0},
		{"<!!!>>", 0},
		{"<{o'i!a,<{i<a>", 10},
	}

	for _, table := range tables {
		value := second(table.testStream)
		if value != table.correct {
			t.Errorf("Testing of %s did not pass, got: %d, want: %d.", table.testStream, value, table.correct)
		}
	}
}
