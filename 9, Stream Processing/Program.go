package main

import (
	"io/ioutil"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func main() {
	dat, err := ioutil.ReadFile("input.txt")
	check(err)

	println("First: ", first(string(dat[:])))
	println("Second: ", second(string(dat[:])))
}

func first(stream string) int {
	garbage := false
	level := 0
	score := 0
	for i := 0; i < len(stream); i++ {
		char := stream[i]
		if char == '>' && garbage {
			garbage = false
		} else if char == '!' {
			i++
		}
		if !garbage {
			if char == '<' {
				garbage = true
			} else if char == '{' {
				level++
				score += level
			} else if char == '}' {
				level--
			}
		}
	}
	return score
}

func second(stream string) int {
	garbage := false
	score := 0
	for i := 0; i < len(stream); i++ {
		char := stream[i]
		if char == '>' && garbage {
			garbage = false
		} else if char == '!' {
			i++
		} else if garbage {
			score++
		}
		if !garbage {
			if char == '<' {
				garbage = true
			}
		}
	}
	return score
}
