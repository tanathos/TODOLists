<template>
  <div class="container">
    <ul v-for="todo in todos" :key="todo.id">
      <nuxt-link :to="'/todos/' + todo.id">
        {{ todo.title }}
      </nuxt-link>
    </ul>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component } from "nuxt-property-decorator";

@Component
export default class TodoIndex extends Vue {
  todos: any[] = [];

  async fetch () {
    this.todos = await this.$axios.$get('http://localhost:3000/todoapi/todos');
  }

  mounted () {
    // await this.fetch();
  }
}
</script>
