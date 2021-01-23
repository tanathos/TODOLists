<template>
  <div class="xl:w-6/12 container">
    <ul v-for="todo in todos" :key="todo.id">
      <nuxt-link :to="'/todos/' + todo.id" class="todo-item p-8 border-4 mb-3 w-full">
        <span class="font-bold">{{ todo.title }}</span>
        <span>{{ todo.createdDate | formatDate }}</span>
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
    this.todos = await this.$axios.$get('/todoapi/todos');
  }

  mounted () {
    // await this.fetch();
  }
}
</script>
